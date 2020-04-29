var jsonConcat = require('json-concat');

// ES
jsonConcat({
    src: "src/assets/i18n/es",
    dest: "src/assets/i18n/es-lang.json"
}, function (json) {
    console.log(json);
});

// EN
jsonConcat({
    src: "src/assets/i18n/en",
    dest: "src/assets/i18n/en-lang.json"
}, function (json) {
    console.log(json);
});
