﻿using System;
using System.Web.Mvc;
using Autofac.Builder;

namespace Autofac.Integration.Mvc.Test
{
    public class ExceptionFilterFixture : AutofacFilterBaseFixture<TestExceptionFilter, TestExceptionFilter2, IExceptionFilter>
    {
        public ExceptionFilterFixture(AutofacFilterTestContext testContext)
            : base(testContext)
        {
        }

        protected override Action<ContainerBuilder> ConfigureActionFilterOverride()
        {
            return builder => builder.OverrideExceptionFilterFor<TestController>(c => c.Action1(default(string)));
        }

        protected override Action<IRegistrationBuilder<TestExceptionFilter, SimpleActivatorData, SingleRegistrationStyle>> ConfigureActionOverrideRegistration()
        {
            return r => r.AsExceptionFilterOverrideFor<TestController>(c => c.Action1(default(string)));
        }

        protected override Action<ContainerBuilder> ConfigureControllerFilterOverride()
        {
            return builder => builder.OverrideExceptionFilterFor<TestController>();
        }

        protected override Action<IRegistrationBuilder<TestExceptionFilter, SimpleActivatorData, SingleRegistrationStyle>> ConfigureControllerOverrideRegistration()
        {
            return r => r.AsExceptionFilterOverrideFor<TestController>();
        }

        protected override Action<IRegistrationBuilder<TestExceptionFilter, SimpleActivatorData, SingleRegistrationStyle>> ConfigureFirstActionRegistration()
        {
            return r => r.AsExceptionFilterFor<TestController>(c => c.Action1(default(string)));
        }

        protected override Action<IRegistrationBuilder<TestExceptionFilter, SimpleActivatorData, SingleRegistrationStyle>> ConfigureFirstControllerRegistration()
        {
            return r => r.AsExceptionFilterFor<TestController>();
        }

        protected override Action<IRegistrationBuilder<TestExceptionFilter2, SimpleActivatorData, SingleRegistrationStyle>> ConfigureSecondActionRegistration()
        {
            return r => r.AsExceptionFilterFor<TestController>(c => c.Action1(default(string)), 20);
        }

        protected override Action<IRegistrationBuilder<TestExceptionFilter2, SimpleActivatorData, SingleRegistrationStyle>> ConfigureSecondControllerRegistration()
        {
            return r => r.AsExceptionFilterFor<TestController>(20);
        }

        protected override Type GetWrapperType()
        {
            return typeof(ExceptionFilterOverride);
        }
    }
}