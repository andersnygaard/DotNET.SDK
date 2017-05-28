﻿using doLittle.Specs.Events.Fakes.v2;
using Machine.Specifications;

namespace doLittle.Specs.Events.for_EventMigrationHierarchy.given
{
    public class an_event_migration_hierarchy_with_two_levels : an_initialized_event_migration_hierarchy
    {
        Establish context = () =>
                                {
                                    event_migration_hierarchy.AddMigrationLevel(typeof(SimpleEvent));
                                    event_migration_hierarchy.AddMigrationLevel(typeof(Fakes.v3.SimpleEvent));
                                };
    }
}