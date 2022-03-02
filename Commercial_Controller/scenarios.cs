using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class ElevatorDetails {
        public int floor;
        public string direction;
        public string status;
        public List<int> floorRequests;

        public ElevatorDetails(int _floor,string _direction,string _status, List<int> _floorRequests) {
            this.floor = _floor;
            this.direction = _direction;
            this.status = _status;
            this.floorRequests = _floorRequests;
        }
    }
    public class Scenarios
    {
        Battery battery = new Battery(1, 4, 60, 6, 5);

        public Column moveAllElevators(Column column) {
            
            for (int i = 0; i < column.elevatorsList.Count; i++)
            {
               
                while (column.elevatorsList[i].floorRequestsList.Count != 0)
                {
                     Console.WriteLine(column.elevatorsList[i].currentFloor);
                    column.elevatorsList[i].move();
                }
            }
            return column;
        }

        public Column setupElevators(Column column, List<ElevatorDetails> elevatorDetails) {
            for (int i = 0; i < column.elevatorsList.Count; i++)
            {
                column.elevatorsList[i].currentFloor = elevatorDetails[i].floor;
                column.elevatorsList[i].direction = elevatorDetails[i].direction;
                column.elevatorsList[i].status = elevatorDetails[i].status;
                column.elevatorsList[i].floorRequestsList = elevatorDetails[i].floorRequests;
            }
            return column;
        }

        public (Column, Elevator) scenario1()
        {
            Column column = battery.columnsList[1];

            ElevatorDetails elevator1 = new ElevatorDetails(20,"down","moving", new List<int>{5});
            ElevatorDetails elevator2 = new ElevatorDetails(3,"up","moving",  new List<int>{15});
            ElevatorDetails elevator3 = new ElevatorDetails(13,"down","moving",new List<int>{1});
            ElevatorDetails elevator4 = new ElevatorDetails(15,"down","moving", new List<int>{2});
            ElevatorDetails elevator5 = new ElevatorDetails(6,"down","moving", new List<int>{2});
            List<ElevatorDetails> elevatorDetails = new List<ElevatorDetails>{elevator1,elevator2,elevator3,elevator4,elevator5};
            battery.columnsList[1] = setupElevators(column, elevatorDetails);

            (Column chosenColumn, Elevator chosenElevator) = battery.assignElevator(20, "up");
            chosenColumn = moveAllElevators(chosenColumn);
            return (chosenColumn, chosenElevator);
        }
        public (Column, Elevator) scenario2()
        {
            Column column = battery.columnsList[2];

            ElevatorDetails elevator1 = new ElevatorDetails(1,"up","stopped", new List<int>{21});
            ElevatorDetails elevator2 = new ElevatorDetails(23,"up","moving",  new List<int>{28});
            ElevatorDetails elevator3 = new ElevatorDetails(33,"down","moving",new List<int>{1});
            ElevatorDetails elevator4 = new ElevatorDetails(40,"down","moving", new List<int>{24});
            ElevatorDetails elevator5 = new ElevatorDetails(39,"down","moving", new List<int>{1});
            List<ElevatorDetails> elevatorDetails = new List<ElevatorDetails>{elevator1,elevator2,elevator3,elevator4,elevator5};
            battery.columnsList[2] = setupElevators(column, elevatorDetails);

            (Column chosenColumn, Elevator chosenElevator) = battery.assignElevator(36, "up");
            chosenColumn = moveAllElevators(chosenColumn);
            return (chosenColumn, chosenElevator);
        }
        public (Column, Elevator) scenario3()
        {
            Column column = battery.columnsList[3];

            ElevatorDetails elevator1 = new ElevatorDetails(58,"down","moving", new List<int>{1});
            ElevatorDetails elevator2 = new ElevatorDetails(50,"up","moving",  new List<int>{60});
            ElevatorDetails elevator3 = new ElevatorDetails(46,"up","moving",new List<int>{58});
            ElevatorDetails elevator4 = new ElevatorDetails(1,"up","moving", new List<int>{54});
            ElevatorDetails elevator5 = new ElevatorDetails(60,"down","moving", new List<int>{1});
            List<ElevatorDetails> elevatorDetails = new List<ElevatorDetails>{elevator1,elevator2,elevator3,elevator4,elevator5};
            setupElevators(column, elevatorDetails);

            Elevator chosenElevator = column.requestElevator(54, "down");
            column = moveAllElevators(column);
            return (column, chosenElevator);
        }
        public (Column, Elevator) scenario4()
        {
            Column column = battery.columnsList[0];

            ElevatorDetails elevator1 = new ElevatorDetails(-4,null,"idle",  new List<int>());
            ElevatorDetails elevator2 = new ElevatorDetails(1,null,"idle",  new List<int>());
            ElevatorDetails elevator3 = new ElevatorDetails(-3,"down","moving",new List<int>{-5});
            ElevatorDetails elevator4 = new ElevatorDetails(-6,"up","moving", new List<int>{1});
            ElevatorDetails elevator5 = new ElevatorDetails(-1,"down","moving", new List<int>{-6});
            List<ElevatorDetails> elevatorDetails = new List<ElevatorDetails>{elevator1,elevator2,elevator3,elevator4,elevator5};
            setupElevators(column, elevatorDetails);

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