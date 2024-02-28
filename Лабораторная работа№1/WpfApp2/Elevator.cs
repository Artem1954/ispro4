using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Elevator
    {
        private readonly int maxFloor;
        public int floorCurrent { get; private set; }

        private enum DoorNow{ open, close };
        private enum GoTo { up, stop, down};


        private DoorNow doorNow;
        private GoTo goTo;

        public delegate void DoorOpen();
        public delegate void DoorColse();
        public delegate void EditFloor();

        public event DoorOpen OpenEvent;
        public event DoorColse CloseEvent;
        public event EditFloor EditFloorEvent;


        public Elevator(int maxFloor)
        {
            this.maxFloor = maxFloor;

            doorNow = DoorNow.close;
            goTo = GoTo.stop;
            floorCurrent = 1;
        }
        public void Up()
        {
            if(doorNow != DoorNow.open)
            {
                if (floorCurrent < maxFloor)
                {
                    floorCurrent++;
                    EditFloorEvent?.Invoke();
                }
            }

        }
        public void Down()
        {
            if (doorNow != DoorNow.open)
            {
                if (floorCurrent > 1)
                {
                    floorCurrent--;
                    EditFloorEvent?.Invoke();
                }
            }
        }

        public void CloseDoor()
        {
            doorNow = DoorNow.close;
            CloseEvent?.Invoke();
        }

        public void OpenDoor()
        {
            doorNow = DoorNow.open;
            OpenEvent?.Invoke();
        }


        public void GoToFloor(int floorTarget)
        {
            for(int i = floorCurrent; i < floorTarget; i++)
            {
                Up();
            }
        }

    }
}
