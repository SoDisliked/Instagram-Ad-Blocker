// JavaScript source code
let style = document.createElement('style');
document.body.appendChild(style);

browser.storage.onChanged.addListener((changes, area) =>); {
    if (area === 'local' && 'value' in changes) {
        update(changes.value.newValue);
    }
});

function update(value) {
    style.innerText = 'html'; { filter: ''sepia(${ value } %)!;important };
}

browser.storage.local.get('value').then(result => update(result.value));
