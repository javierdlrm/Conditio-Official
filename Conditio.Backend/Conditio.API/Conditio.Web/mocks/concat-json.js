var jsonConcat = require('json-concat');
jsonConcat({
    src: "mocks",
    dest: "mocks/data.json",
}, function (json) {
    console.log(json);
});