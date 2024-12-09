namespace CCAD16_Assignment6_1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // House data
            House house1 = new House(1428, "Elm Street", "Victorian");
            House house2 = new House(261, "Turner Lane", "Colonial");
            House house3 = new House(1600, "Pennsylvania Ave.", "Big White House");

            // Node creation
            Node node1 = new Node(house1);
            Node node2 = new Node(house2);
            Node node3 = new Node(house3);

            // Linking nodes
            node1.next = node2;
            node2.next = node3;
            node3.next = null;

            // Set node at beginning of LL
            LinkedList houseList = new LinkedList(node1);

            // Display all houses
            houseList.DisplayHouses();

            // Find a specific house by house number
            House foundHouse = houseList.FindElement(261);
            if (foundHouse != null)
            {
                Console.WriteLine($"Found House: {foundHouse.houseNum} - {foundHouse.address} ({foundHouse.houseType})");
            }
            else
            {
                Console.WriteLine("House not found.");
            }
        }
    }

    class House
    {
        public int houseNum { get; set; }
        public string address { get; set; }
        public string houseType { get; set; }

        public House(int number, string addr, string type)
        {
            houseNum = number;
            address = addr;
            houseType = type;
        }
    }

    internal class Node
    {
        internal House data; // Node value
        internal Node next; // Pointer to the next node
        public Node(House house) // Constructor
        {
            data = house;
            next = null;
        }
    }

    internal class LinkedList
    {
        private Node head; // First node in the linked list

        // Constructor that accepts the first node (head)
        public LinkedList(Node firstNode)
        {
            head = firstNode;
        }

        // Find a house by house number
        public House FindElement(int houseNum)
        {
            Node current = head;
            while (current != null)
            {
                if (current.data.houseNum == houseNum)
                {
                    return current.data; // Return the house if found
                }
                current = current.next; // Move to the next node
            }
            return null; // Return null if the house is not found
        }

        // Display all houses in the linked list
        public void DisplayHouses()
        {
            Node current = head;
            while (current != null)
            {
                DisplayDetails(current.data);
                current = current.next;
            }
        }

        // Method to display house details
        private void DisplayDetails(House house)
        {
            Console.WriteLine($"House Number: {house.houseNum}");
            Console.WriteLine($"Address: {house.address}");
            Console.WriteLine($"Type: {house.houseType}");
            Console.WriteLine("------------------------");
        }
    }
}
