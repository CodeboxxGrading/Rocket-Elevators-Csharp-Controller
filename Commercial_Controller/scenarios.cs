using System;

namespace Commercial_Controller
{
    public class Scenarios
    {
        Battery battery = new Battery(1, 4, 60, 6, 5);

        public Column moveAllElevators(Column column) {
            for (int i = 0; i < column.elevatorsList.Count; i++)
            {
                while (column.elevatorsList[i].floorRequestsList.Count != 0)
                {
                    column.elevatorsList[i].move();
                }
            }
            return column;
        }

        public (Column, Elevator) scenario1()
        {
            Column column = battery.columnsList[1];

            column.elevatorsList[0].currentFloor = 20;
            column.elevatorsList[0].direction = "down";
            column.elevatorsList[0].status = "moving";
            column.elevatorsList[0].floorRequestsList.Add(5);

            column.elevatorsList[1].currentFloor = 3;
            column.elevatorsList[1].direction = "up";
            column.elevatorsList[1].status = "moving";
            column.elevatorsList[1].floorRequestsList.Add(15);

            column.elevatorsList[2].currentFloor = 13;
            column.elevatorsList[2].direction = "down";
            column.elevatorsList[2].status = "moving";
            column.elevatorsList[2].floorRequestsList.Add(1);

            column.elevatorsList[3].currentFloor = 15;
            column.elevatorsList[3].direction = "down";
            column.elevatorsList[3].status = "moving";
            column.elevatorsList[3].floorRequestsList.Add(2);

            column.elevatorsList[4].currentFloor = 6;
            column.elevatorsList[4].direction = "down";
            column.elevatorsList[4].status = "moving";
            column.elevatorsList[4].floorRequestsList.Add(2);

            (Column chosenColumn, Elevator chosenElevator) = battery.assignElevator(20, "up");
            chosenColumn = moveAllElevators(chosenColumn);
            return (chosenColumn, chosenElevator);
        }
        public (Column, Elevator) scenario2()
        {
            Column column = battery.columnsList[2];

            column.elevatorsList[0].currentFloor = 1;
            column.elevatorsList[0].direction = "up";
            column.elevatorsList[0].status = "stopped";
            column.elevatorsList[0].floorRequestsList.Add(21);

            column.elevatorsList[1].currentFloor = 23;
            column.elevatorsList[1].direction = "up";
            column.elevatorsList[1].status = "moving";
            column.elevatorsList[1].floorRequestsList.Add(28);

            column.elevatorsList[2].currentFloor = 33;
            column.elevatorsList[2].direction = "down";
            column.elevatorsList[2].status = "moving";
            column.elevatorsList[2].floorRequestsList.Add(1);

            column.elevatorsList[3].currentFloor = 40;
            column.elevatorsList[3].direction = "down";
            column.elevatorsList[3].status = "moving";
            column.elevatorsList[3].floorRequestsList.Add(24);

            column.elevatorsList[4].currentFloor = 39;
            column.elevatorsList[4].direction = "down";
            column.elevatorsList[4].status = "moving";
            column.elevatorsList[4].floorRequestsList.Add(1);

            (Column chosenColumn, Elevator chosenElevator) = battery.assignElevator(36, "up");
            chosenColumn = moveAllElevators(chosenColumn);
            return (chosenColumn, chosenElevator);
        }
        public (Column, Elevator) scenario3()
        {
            Column column = battery.columnsList[3];

            column.elevatorsList[0].currentFloor = 58;
            column.elevatorsList[0].direction = "down";
            column.elevatorsList[0].status = "moving";
            column.elevatorsList[0].floorRequestsList.Add(1);

            column.elevatorsList[1].currentFloor = 50;
            column.elevatorsList[1].direction = "up";
            column.elevatorsList[1].status = "moving";
            column.elevatorsList[1].floorRequestsList.Add(60);

            column.elevatorsList[2].currentFloor = 46;
            column.elevatorsList[2].direction = "up";
            column.elevatorsList[2].status = "moving";
            column.elevatorsList[2].floorRequestsList.Add(58);

            column.elevatorsList[3].currentFloor = 1;
            column.elevatorsList[3].direction = "up";
            column.elevatorsList[3].status = "moving";
            column.elevatorsList[3].floorRequestsList.Add(54);

            column.elevatorsList[4].currentFloor = 60;
            column.elevatorsList[4].direction = "down";
            column.elevatorsList[4].status = "moving";
            column.elevatorsList[4].floorRequestsList.Add(1);

            //We make the request
            Elevator chosenElevator = column.requestElevator(54, "down");
            column = moveAllElevators(column);
            return (column, chosenElevator);
        }
        public (Column, Elevator) scenario4()
        {
            Column column = battery.columnsList[0];

            column.elevatorsList[0].currentFloor = -4;

            column.elevatorsList[1].currentFloor = 1;

            column.elevatorsList[2].currentFloor = -3;
            column.elevatorsList[2].direction = "down";
            column.elevatorsList[2].status = "moving";
            column.elevatorsList[2].floorRequestsList.Add(-5);

            column.elevatorsList[3].currentFloor = -6;
            column.elevatorsList[3].direction = "up";
            column.elevatorsList[3].status = "moving";
            column.elevatorsList[3].floorRequestsList.Add(1);

            column.elevatorsList[4].currentFloor = -1;
            column.elevatorsList[4].direction = "down";
            column.elevatorsList[4].status = "moving";
            column.elevatorsList[4].floorRequestsList.Add(-6);

            //We make the request
            Elevator chosenElevator = column.requestElevator(-3, "up");
            column = moveAllElevators(column);
            return (column, chosenElevator);
        }
        public void run(int scenarioNumber)
        {
            switch(scenarioNumber) {
                case 1:
                    scenario1();
                    break;
                case 2:
                    scenario2();
                    break;
                case 3:
                    scenario3();
                    break;
                case 4:
                    scenario4();
                    break;
                default:
                    Console.WriteLine("Invalid scenario number");
                    break;
            }            
        }
    }

}