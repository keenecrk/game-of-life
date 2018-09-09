using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Library.Tests
{
    /*****Rules*****
     * Any live cell with fewer than two live neighbors dies.
     * Any live cell with two or three live neighbors lives.
     * Any live cell with more than three live neighbors dies
     * Any dead cell with exactly three live neighbors becomes a live cell
     */

    [TestFixture]
    public class LifeRulesTests
    {
        [Test]
        public void LiveCell_FewerThan2LiveNeighbors_Dies(
            [Range(0,1)] int liveNeighbors)
        {
            var currentState = CellState.Alive;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void LiveCell_2Or3LiveNeighbors_Lives(
            [Range(2, 3)] int liveNeighbors)
        {
            var currentState = CellState.Alive;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void LiveCell_MoreThan3LiveNeighbors_Dies(
            [Range(4, 8)] int liveNeighbors)
        {
            var currentState = CellState.Alive;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void DeadCell_Exactly3LiveNeighbores_BecomesAlive()
        {
            var liveNeighbors = 3;
            var currentState = CellState.Dead;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void DeadCell_LessThan3LiveNeighbors_StaysDead(
            [Range(0, 2)] int liveNeighbors)
        {
            var currentState = CellState.Dead;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void DeadCell_MoreThan3LiveNeighbors_StaysDead(
            [Range(4, 8)] int liveNeighbors)
        {
            var currentState = CellState.Dead;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }
    }
}
