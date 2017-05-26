﻿Bifrost.namespace("Bifrost.validation", {
    length: Bifrost.validation.Rule.extend(function () {
        var self = this;

        function notSet(value) {
            return Bifrost.isUndefined(value) || Bifrost.isNull(value);
        }

        function throwIfValueIsNotANumber(value) {
            if (!Bifrost.isNumber(value)) {
                throw new Bifrost.validation.NotANumber("Value " + value + " is not a number");
            }
        }

        function throwIfOptionsInvalid(options) {
            if (notSet(options)) {
                throw new Bifrost.validation.OptionsNotDefined();
            }
            if (notSet(options.max)) {
                throw new Bifrost.validation.MaxLengthNotSpecified();
            }
            if (notSet(options.min)) {
                throw new Bifrost.validation.MinLengthNotSpecified();
            }
            throwIfValueIsNotANumber(options.min);
            throwIfValueIsNotANumber(options.max);
        }

        this.validate = function (value) {
            throwIfOptionsInvalid(self.options);
            if (notSet(value)) {
                value = "";
            }
            if (!Bifrost.isString(value)) {
                value = value.toString();
            }
            return self.options.min <= value.length && value.length <= self.options.max;
        };
    })
});