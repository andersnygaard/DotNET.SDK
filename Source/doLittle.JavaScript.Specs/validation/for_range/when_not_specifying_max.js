﻿describe("when not specifying max", function () {
    var exception = null;
    try {
        var validator = doLittle.validation.range.create({ options: { min: 5 } });
        validator.validate("1234");
    } catch (e) {
        exception = e;
    }

    it("should throw an exception", function () {
        expect(exception instanceof doLittle.validation.MaxNotSpecified).toBe(true);
    });
});