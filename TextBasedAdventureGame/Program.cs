using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBasedAdventureGame
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool playing = true;
            Game theGame = new Game();
            theGame.reset();
            Console.WriteLine("WATER\nLOOK AROUND\nTEST INVENTORY\nINVENTORY\n");
            while (playing == true)
            {
                theGame.checkIfValid(Console.ReadLine());
            }
        }
    }

    public class Game
    {
        bool beenHereWater = false;
        bool lookedAround = false;
        public Hashtable inventory = new Hashtable();
        public string inventoryItem = "";
        public int inventoryKey = 0;

        public void reset()
        {
            //inventory.Add("EndOfInv");

            beenHereWater = false;
            lookedAround = false;
        }

        public void checkIfValid(string toCheck)
        {
            whereTo(toCheck);
        }

        private void whereTo(string toHere)
        {
            Console.Clear();
            toHere = toHere.ToUpper();
            switch (toHere)
            {
                case "WATER":
                    waterStuff();
                    break;

                case "LOOK AROUND":
                    LookAround();
                    break;

                case "TEST":
                    testInventory();
                    break;

                case "INVENTORY":
                    printInventory();
                    break;

                case "EXIT":
                    
                    break;
            }
        }

        private void printInventory()
        {
            Console.WriteLine("INVENTORY");
            foreach (string inventoryitem in inventory.Keys)
            {
                Console.WriteLine(inventoryitem.ToUpper());
            }
        }

        private void waterStuff()
        {
            foreach(string inventoryItem in inventory)
            {
                if (inventoryItem == "Rope")
                {
                    Console.WriteLine("You look around warily, fearing the rapids. You look around your bag for something to assist in crossing, and find a rope. It takes a coupld of tries, but you manage to hook the rope on a tough rock, and cross safely");
                    beenHereWater = true;
                    inventory.Remove("Rope");
                    return;
                }

                else
                {
                    continue;
                }
            }

            if (beenHereWater == true)
            {
                Console.WriteLine("Having been here already, you cockily attempt to traverse the rapids. Your quick steps lead to your downfall");
                reset();
            }

            else
            {
                Console.WriteLine("You gaze around in wonder. Having never seen such quick rapids before, so you take your time crossing. Unfortunately, taking your time means you were in the way when a tree came down, knocking you into the water, where you freeze/drown/get clubbed by a tree to death.");
            }
        }

        private void testInventory()
        {
            addToInventory(Console.ReadLine());
        }

        private void addToInventory(string item)
        {
            if (inventoryKey > 3)
            {
                inventoryFull(item);
            }
            else
            {
                inventory.Add(item, inventoryKey);
                inventoryKey++;
            }
        }

        private void inventoryFull(string itemToGet)
        {
            Console.WriteLine("Your inventory is full. You'll have to drop an item to pick up that " + itemToGet + ".");
            foreach (DictionaryEntry inventoryitem in inventory)
            {
                Console.WriteLine(inventoryitem.Value as string);
            }

            string thingToDrop = Console.ReadLine();

            foreach (string inventoryitem in inventory)
            {
                if (inventoryitem == thingToDrop)
                {
                    inventory.Remove(thingToDrop);

                }

                else
                {
                    continue;
                }
            }
        }

        private void LookAround()
        {
            if (lookedAround == false)
            {
                Console.WriteLine("You look around, and find a rope on the ground nearby!");
                foreach (string inventoryItem in inventory)
                {
                    if (inventoryItem == null)
                    {
                        //inventory.Add("Rope");
                        lookedAround = true;
                        return;
                    }

                    else if (inventoryItem == "EndOfInv")
                    {
                        inventoryFull("Rope");
                        lookedAround = true;
                        return;
                    }
                }
            }

            else
            {
                Console.WriteLine("You've already looked around. There is nothing interesting anymore");
            }
        }
    }
}
