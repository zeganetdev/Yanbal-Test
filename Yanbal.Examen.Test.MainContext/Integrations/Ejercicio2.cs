using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Yanbal.Examen.Application.MainContext.AppServices.Contracts;
using Yanbal.Examen.Application.MainContext.AppServices.Implementations;

namespace Yanbal.Examen.Test.MainContext.Integrations
{
    [TestFixture]
    public class Ejercicio2
    {

        IRangosAppServices rangos;

        #region "Privates"

        private IEnumerable<int> GetListRango_1()
        {
            return new int[] { 2, 1, 4, 5 };
        }

        private IEnumerable<int> GetListRangoAssert_1()
        {
            return new int[] { 1, 2, 3, 4, 5 };
        }

        private IEnumerable<int> GetListRango_2()
        {
            return new int[] { 100, 96, 101, 102, 105 };
        }

        private IEnumerable<int> GetListRangoAssert_2()
        {
            return new int[] { 96, 97, 98, 99, 100, 101, 102, 103, 104, 105 };
        }

        private IEnumerable<int> GetListRango_3()
        {
            return new int[] { 22, 25 };
        }

        private IEnumerable<int> GetListRangoAssert_3()
        {
            return new int[] { 22, 23, 24, 25 };
        }
        #endregion

        [SetUp]
        public void SetUp()
        {
            rangos = new RangosAppServices();
        }


        [Test]
        public void T201_EJERCICIO_2_COMPLETAR_RANGO_ORDENAR()
        {
            //Arrange
            IEnumerable<int> expected = GetListRangoAssert_1();

            //Act
            IEnumerable<int> result = rangos.CompletarRango(GetListRango_1());

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void T202_EJERCICIO_2_COMPLETAR_RANGO_ORDENAR()
        {
            //Arrange
            IEnumerable<int> expected = GetListRangoAssert_2();

            //Act
            IEnumerable<int> result = rangos.CompletarRango(GetListRango_2());

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void T203_EJERCICIO_2_COMPLETAR_RANGO_ORDENAR()
        {
            //Arrange
            IEnumerable<int> expected = GetListRangoAssert_3();

            //Act
            IEnumerable<int> result = rangos.CompletarRango(GetListRango_3());

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
