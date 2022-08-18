// JavaScript source code
let input = document.querySelector('input');

input.addEventListener('change', e => setValue(e.target.value));

async function setValue(value) {
    await browser.storage.local.set({ value });
}

async function init() {
    let { value } = browser.storage.local.get('value');
    if (!value) {
        value = 0;
    }
    input.value = value;
    setValue(value);
}

init().catch(e => console.error(e));