﻿describe("when resolving and resolver can resolve", function () {
    var resolveCalled = false;
    var systemReceived = null;
    var system = { blah: "something" };

    var dependencyResolvers;

    beforeEach(function () {
        dependencyResolvers = Bifrost.dependencyResolvers;

        Bifrost.dependencyResolvers = {

            getAll: function () {
                return [{
                    canResolve: sinon.stub().returns(true),
                    resolve: function () {
                        resolveCalled = true;
                        return system;
                    }
                }];
            }
        };
        systemReceived = Bifrost.dependencyResolver.resolve("something");
    });

    afterEach(function () {
        Bifrost.dependencyResolvers = dependencyResolvers;
    });

    it("should call resolve", function () {
        expect(resolveCalled).toBe(true);
    });

    it("should return the system it can resolve", function () {
        expect(systemReceived).toBe(system);
    });
});