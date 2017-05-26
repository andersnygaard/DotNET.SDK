describe("when creating asynchronously", function() {
	var type = Bifrost.Type.extend(function() {
	});

	var result = type.beginCreate();

	it("should return a promise", function() {
		expect(result instanceof Bifrost.execution.Promise).toBe(true);
	});
});