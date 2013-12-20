﻿describe("when command in child region can execute", function () {

    var tasks = {
        all: ko.observableArray()
    };

    var messengerFactory = {
        create: function () { },
        global: function () { }
    };
    var operationsFactory = {
        create: function () { return { all: ko.observableArray() }}
    };
    var tasksFactory = {
        create: function () {
            return tasks;
        }
    };

    var region = new Bifrost.views.Region(
        messengerFactory,
        operationsFactory,
        tasksFactory
    );
    var canExecute = false;
    region.canCommandsExecute.subscribe(function (newValue) {
        canExecute = newValue;
    });

    var childRegion = {
        isLoading: ko.observable(false),
        isBusy: ko.observable(false),
        isValid: ko.observable(false),
        isComposing: ko.observable(false),
        isExecuting: ko.observable(false),
        validationMessages: ko.observableArray(),
        aggregatedCommands: ko.observableArray(),
        canCommandsExecute: ko.observable(false),
        areCommandsAuthorized: ko.observable(false),
        commandsHaveChanges: ko.observable(false),
        areCommandsReadyToExecute: ko.observable(false),
        hasChanges: ko.observable(false),
        commands: ko.observableArray()
    };

    var command = {
        isValid: ko.observable(false),
        isAuthorized: ko.observable(false),
        canExecute: ko.observable(false),
        hasChanges: ko.observable(false),
        isReadyToExecute: ko.observable(false),
        validators: ko.observableArray()
    };
    childRegion.commands.push(command);

    command.canExecute(true);

    region.children.push(childRegion);

    it("should be able to execute", function () {
        expect(canExecute).toBe(true);
    });
});