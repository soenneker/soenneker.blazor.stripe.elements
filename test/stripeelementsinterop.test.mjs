import assert from 'node:assert/strict';
import { readFile } from 'node:fs/promises';
import test from 'node:test';

const source = await readFile(new URL('../src/Soenneker.Blazor.Stripe.Elements/wwwroot/js/stripeelementsinterop.js', import.meta.url), 'utf8');
const interop = await import(`data:text/javascript;base64,${Buffer.from(source).toString('base64')}`);

test('deferred payment passes the submitted Elements, secret and return URL to Stripe', async () => {
    const calls = [];
    const elements = { submit: async () => { calls.push('submit'); return {}; } };
    const confirmation = { paymentIntent: { id: 'pi_test', status: 'succeeded' } };
    globalThis.window = { Stripe: () => ({
        elements: options => { assert.equal(options.amount, 10000); return elements; },
        confirmPayment: async options => { calls.push(options); return confirmation; }
    }) };
    await interop.create('payment', JSON.stringify({ publishableKey: 'pk_test', elementsOptions: { amount: 10000, currency: 'usd', mode: 'payment' } }), { invokeMethodAsync: async () => {} });
    assert.deepEqual(await interop.submit('payment'), {});
    assert.equal(await interop.confirmPayment('payment', 'test_secret', 'https://example.com/receipt'), confirmation);
    assert.deepEqual(calls, ['submit', {
        elements, clientSecret: 'test_secret', confirmParams: { return_url: 'https://example.com/receipt' }, redirect: 'if_required'
    }]);
    interop.unmountGroup('payment');
    await assert.rejects(interop.confirmPayment('payment', 'test_secret', 'https://example.com/receipt'), /not found for confirmPayment/);
});

test('missing payment and setup groups fail explicitly instead of returning an empty result', async () => {
    await assert.rejects(interop.confirmPayment('missing', 'test_secret', 'https://example.com'), /not found for confirmPayment/);
    await assert.rejects(interop.confirmSetup('missing', 'test_secret', 'https://example.com'), /not found for confirmSetup/);
});

test('Stripe validation errors reach the caller unchanged', async () => {
    const failure = { error: { type: 'validation_error', message: 'Payment details are incomplete.' } };
    globalThis.window = { Stripe: () => ({ elements: () => ({}), confirmPayment: async () => failure }) };
    await interop.create('invalid-payment', JSON.stringify({ publishableKey: 'pk_other_test' }), { invokeMethodAsync: async () => {} });
    assert.equal(await interop.confirmPayment('invalid-payment', 'test_secret', 'https://example.com'), failure);
    interop.unmountGroup('invalid-payment');
});
