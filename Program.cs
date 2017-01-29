using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algorithm_Kruskal
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialization();
            Kruskal();
            Output();
            Console.ReadLine();
        }

        // struct
        struct Edge
        {
            public int u, v;
        }

        // Variables
        static int[,] graph; // do thi
        static List<int> MST; // danh sach dinh trong cay khung
        static List<Edge> EDGE; // danh sach canh trong cay khung

        // method
        static void Kruskal()
        {
            List<Edge> lstEdge;
            int[] Label;
            int n = graph.GetLength(0);

            // buoc 1: tao danh sach canh, sap xep tang dan trong so
            lstEdge = new List<Edge>(); // danh sach canh
            Label = new int[n];
            for (int i = 0; i < n; i++ )
            {
                Label[i] = i;
                for (int j = i + 1; j < n; j++)
                {
                    if(graph[i, j] != 0)
                    {
                        Edge e = new Edge();
                        e.u = i; e.v = j;
                        lstEdge.Add(e);
                    }
                }
            }
            // xuat danh sach sap xep
            Console.WriteLine("Danh sach canh: (u,v) : w");
            foreach (Edge e in lstEdge)
            {
                Console.WriteLine("({0},{1}) : {2}", e.u, e.v, graph[e.u, e.v]);
            }
            Console.WriteLine();

            for (int i = 0; i < lstEdge.Count - 1; i++)
            {
                for (int j = i + 1; j < lstEdge.Count; j++)
                {
                    if (CompareEdge(lstEdge[i], lstEdge[j]) == 1)
                    {
                        Edge t = lstEdge[i];
                        lstEdge[i] = lstEdge[j];
                        lstEdge[j] = t;
                    }
                }
            }

            // buoc 2: tao cay T, duyet danh sach
            foreach(Edge e in lstEdge)
            {
                if (Label[e.u] != Label[e.v])
                {
                    // them canh vao cay
                    EDGE.Add(e);
                    Console.WriteLine("Add ({0}, {1}) to EDGE MST", e.u, e.v);

                    // them dinh vao danh sach canh cua cay
                    if (!MST.Contains(e.u)) MST.Add(e.u);
                    if (!MST.Contains(e.v)) MST.Add(e.v);

                    // thay doi nhan
                    int lab1 = (Label[e.u] < Label[e.v]) ? Label[e.u] : Label[e.v]; // lay cai nho nhat
                    int lab2 = (Label[e.u] > Label[e.v]) ? Label[e.u] : Label[e.v]; // lay cai lon nhat
                    for (int i = 0; i < n; i++)
                    {
                        if (Label[i] == lab2) Label[i] = lab1;
                    }
                }
            }
        }

        // compare
        static int CompareEdge(Edge e1, Edge e2)
        {
            if (graph[e1.u, e1.v] > graph[e2.u, e2.v]) return 1;
            else if (graph[e1.u, e1.v] == graph[e2.u, e2.v]) return 0;
            return -1;
        }

        // initial
        static void Initialization()
        {
            //graph = new int[,]
            //{
            //    {0,5,0,3,0},
            //    {5,0,0,8,10},
            //    {0,0,0,7,0},
            //    {3,8,7,0,1},
            //    {0,10,0,1,0}
            //};

            graph = new int[,] 
            {
                {0,7,0,5,0,0,0},
                {7,0,8,9,7,0,0},
                {0,8,0,0,5,0,0},
                {5,9,0,0,15,6,0},
                {0,7,5,15,0,8,9},
                {0,0,0,6,8,0,11},
                {0,0,0,0,9,11,0}
            };
            MST = new List<int>();
            EDGE = new List<Edge>();
        }

        static void Output()
        {
            Console.Write("Danh sach dinh: ");
            foreach (int i in MST)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            Console.Write("Danh sach canh: ");
            foreach (Edge e in EDGE)
            {
                Console.Write("({0}, {1}) ", e.u, e.v);
            }
        }
    }
}
