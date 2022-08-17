﻿using ExamenPGG.Business._00_Interfaces;
using ExamenPGG.Business._01_Classes;

namespace ExamenPGG.Business.Tests
{
    public class PlayerTests
    {
        private IPlayer player;

        [SetUp]
        public void Setup()
        {
            player = new Player();
        }

        [TestCase(5, 5, 10)]
        [TestCase(45, 5, 50)]
        [TestCase(37, 1, 38)]
        [TestCase(11, 24, 35)]
        [TestCase(58, 8, 60)]
        public void MovePlayerAsync_EqualTest(int startPosition, int moveAmount, int expectedResult)
        {
            // Arrange
            player.CurrentSquare = startPosition;

            // Act
            int result = player.MovePlayerAsync(moveAmount);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(5, 12, 7)]
        [TestCase(45, 7, 46)]
        [TestCase(37, 1, 42)]
        [TestCase(58, 8, 66)]
        [TestCase(54, 10, 64)]
        public void MovePlayerAsync_NotEqualTest(int startPosition, int moveAmount, int expectedResult)
        {
            // Arrange
            player.CurrentSquare = startPosition;

            // Act
            int result = player.MovePlayerAsync(moveAmount);

            // Assert
            Assert.That(result, Is.Not.EqualTo(expectedResult));
        }
    }
}