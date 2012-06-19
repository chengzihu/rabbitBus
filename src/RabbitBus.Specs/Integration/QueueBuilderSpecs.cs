﻿using System.Collections.Generic;
using Machine.Specifications;
using RabbitBus.Specs.Infrastructure;
using RabbitBus.Utilities;

namespace RabbitBus.Specs.Integration
{
	[Integration]
	[Subject("Queues")]
	public class when_creating_a_queue
	{
		const string SpecId = "875C047E-BAD2-4A58-BC92-1DAAD2D6B0AA";
		static bool _queueExists;

		Establish context = () => new QueueBuilder()
		                          	.WithConnection("amqp://guest:guest@localhost:5672/%2f")
		                          	.WithName(SpecId)
		                          	.WithExchange(SpecId, cfg => cfg.Direct())
		                          	.WithRoutingKey(string.Empty)
		                          	.Declare();

		Because of = () => _queueExists = RabbitQueue.QueueExists(SpecId);

		It should_create_the_queue = () => _queueExists.ShouldBeTrue();
	}

	[Integration]
	[Subject("Queues")]
	public class when_creating_a_queue_with_headers
	{
		const string SpecId = "875C047E-BAD2-4A58-BC92-1DAAD2D6B0AA";
		static bool _queueExists;

		Establish context = () => new QueueBuilder()
																.WithConnection("amqp://guest:guest@localhost:5672/%2f")
																.WithName(SpecId)
																.WithExchange(SpecId, cfg => cfg.Direct())
																.WithHeaders(new Dictionary<string, object>())
																.Declare();

		Because of = () => _queueExists = RabbitQueue.QueueExists(SpecId);

		It should_create_the_queue = () => _queueExists.ShouldBeTrue();
	}
}