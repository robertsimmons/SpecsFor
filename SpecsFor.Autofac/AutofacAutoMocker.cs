﻿using Moq;
using Autofac.Extras.Moq;
using SpecsFor.Core;

namespace SpecsFor.Autofac
{
    public class AutofacAutoMocker : IAutoMocker
    {
        private AutoMock _mocker;

        public TSut CreateSUT<TSut>() where TSut : class
        {
            return _mocker.Create<TSut>();
        }

        public Mock<T> GetMockFor<T>() where T : class
        {
            return _mocker.Mock<T>();
        }

        public void ConfigureContainer<TSut>(ISpecs<TSut> specsFor) where TSut : class
        {
            var specs = (SpecsFor<TSut>) specsFor;

            _mocker = specs.CreateMocker();

            specs.ConfigureMocker(_mocker);
        }
    }
}