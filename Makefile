build:
	@docker-compose build
.PHONY: build

test: clean build
	@docker-compose run --rm smoke-tests
.PHONY: test

clean:
	@docker-compose down
.PHONY: clean