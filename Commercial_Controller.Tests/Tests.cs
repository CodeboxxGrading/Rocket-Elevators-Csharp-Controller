using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commercial_Controller.Tests
{
    [TestClass]
    public class UnitTest1
    {

        public void AssertElevatorsPosition(Column chosenColumn, int[] expectedFinalPositions) {
            for (int i = 0; i < chosenColumn.elevatorsList.Count; i++)
            {
                Assert.AreEqual(chosenColumn.elevatorsList[i].currentFloor, expectedFinalPositions[i], "Elevator " + chosenColumn.elevatorsList[i].ID + " didn't finish at the correct floor, expected " + expectedFinalPositions[i] + ", got " + chosenColumn.elevatorsList[0].currentFloor);
            }
        }

        [TestMethod]

        public void TestScenario1()
        {
            Battery battery = new Battery(1, 4, 60, 6, 5);
            Scenarios scenarios = new Scenarios();

            Column expectedColumn = battery.columnsList[1];
            Elevator expectedElevator = battery.columnsList[1].elevatorsList[4];
            int userPosition = 1;
            int destination = 20;
            int[] expectedFinalPositions = { 5, 15, 1, 2, 20 };

            (Column chosenColumn, Elevator chosenElevator) = scenarios.scenario1();

            Assert.AreEqual(chosenColumn.ID, expectedColumn.ID, "Wrong column selected, expected Column " + expectedColumn.ID + ", got Column " + chosenColumn.ID);

            Assert.AreEqual(chosenElevator.ID, expectedElevator.ID, "Wrong elevator selected, expected Elevator " + expectedElevator.ID + ", got Elevator " + expectedElevator.ID);

            Assert.IsTrue(chosenElevator.completedRequestsList.Contains(userPosition), "No elevator was sent to pick up the user");

            Assert.IsTrue(chosenElevator.completedRequestsList.Contains(userPosition) && chosenElevator.currentFloor == destination, "The user didn't reach its destination");

            AssertElevatorsPosition(chosenColumn, expectedFinalPositions);
        }

        [TestMethod]
        public void TestScenario2()
        {
            Battery battery = new Battery(1, 4, 60, 6, 5);
            Scenarios scenarios = new Scenarios();

            Column expectedColumn = battery.columnsList[2];
            Elevator expectedElevator = expectedColumn.elevatorsList[0];
            int userPosition = 1;
            int destination = 36;
            int[] expectedFinalPositions = { 36, 28, 1, 24, 1 };

            (Column chosenColumn, Elevator chosenElevator) = scenarios.scenario2();

            Assert.AreEqual(chosenColumn.ID, expectedColumn.ID, "Wrong column selected, expected Column " + expectedColumn.ID + ", got Column " + chosenColumn.ID);

            Assert.AreEqual(chosenElevator.ID, expectedElevator.ID, "Wrong elevator selected, expected Elevator " + expectedElevator.ID + ", got Elevator " + chosenElevator.ID);

            Assert.IsTrue(chosenElevator.completedRequestsList.Contains(userPosition), "No elevator was sent to pick up the user");

            Assert.IsTrue(chosenElevator.completedRequestsList.Contains(userPosition) && chosenElevator.currentFloor == destination, "The user didn't reach its destination");

            AssertElevatorsPosition(chosenColumn, expectedFinalPositions);
        }

        [TestMethod]
        public void TestScenario3()
        {
            Battery battery = new Battery(1, 4, 60, 6, 5);
            Scenarios scenarios = new Scenarios();

            (Column columnUsed, Elevator chosenElevator) = scenarios.scenario3();

            Elevator expectedElevator = columnUsed.elevatorsList[0];
            int userPosition = 54;
            int destination = 1;
            int[] expectedFinalPositions = { 1, 60, 58, 54, 1 };

            Assert.AreEqual(chosenElevator.ID, expectedElevator.ID, "Wrong elevator selected, expected Elevator " + expectedElevator.ID + ", got Elevator " + chosenElevator.ID);

            Assert.IsTrue(chosenElevator.completedRequestsList.Contains(userPosition), "No elevator was sent to pick up the user");

            Assert.IsTrue(chosenElevator.completedRequestsList.Contains(userPosition) && chosenElevator.currentFloor == destination, "The user didn't reach its destination");

            AssertElevatorsPosition(columnUsed, expectedFinalPositions);
        }

        [TestMethod]
        public void TestScenario4()
        {
            Battery battery = new Battery(1, 4, 60, 6, 5);
            Scenarios scenarios = new Scenarios();

            (Column columnUsed, Elevator chosenElevator) = scenarios.scenario4();

            Elevator expectedElevator = columnUsed.elevatorsList[3];
            int userPosition = -3;
            int destination = 1;
            int[] expectedFinalPositions = { -4, 1, -5, 1, -6 };

            Assert.AreEqual(chosenElevator.ID, expectedElevator.ID, "Wrong elevator selected, expected Elevator " + expectedElevator.ID + ", got Elevator " + chosenElevator.ID);

            Assert.IsTrue(chosenElevator.completedRequestsList.Contains(userPosition), "No elevator was sent to pick up the user");

            Assert.IsTrue(chosenElevator.completedRequestsList.Contains(userPosition) && chosenElevator.currentFloor == destination, "The user didn't reach its destination");

            AssertElevatorsPosition(columnUsed, expectedFinalPositions);
        }
    }
}