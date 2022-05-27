using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
    public class Cell
    {
        public bool IsAlive;
        public bool IsAliveNext;

        public List<Cell> neighbors = new();
    }
 
