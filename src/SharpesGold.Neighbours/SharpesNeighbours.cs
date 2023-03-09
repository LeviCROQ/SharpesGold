namespace SharpesGold.Neighbours;

public class SharpesNeighbours
{
    private int Size;
    private bool[] Unvisited;
    public int UnvisitedCount;

    public SharpesNeighbours(int size)
    {
        this.Size = size;
        this.Unvisited = Enumerable.Repeat(true, size*size).ToArray();
        this.UnvisitedCount = size*size;
    }
    
    // ------------------------------------------------------------
    // For the specified node index, return all valid neighbours.
    // In this case, valid means nodes that are unvisited, inside
    // bounds and not selected (i.e. blocked).
    // ------------------------------------------------------------
    public int[] Calculate(int index)
    {
        List<int> neighbors = new List<int>();
        
        // NORTH?
        if (index > this.Size) {
            int indexNorth = index - this.Size;
            if (IsUnvisited(indexNorth)) {
                neighbors.Add(indexNorth);
            }

            // NORTH-EAST?
            if ((index % this.Size) != (this.Size - 1)) {
                int indexNorthEast = indexNorth + 1;
                if (IsUnvisited(indexNorthEast)) {
                    neighbors.Add(indexNorthEast);
                }
            }
        }

        // EAST?
        // Check index is not rightmost in grid (hint, NORTH-EAST?)
        if ((index % this.Size) != (this.Size - 1)) {
             int indexEast = index + 1;
             if (IsUnvisited(indexEast)) {
                 neighbors.Add(indexEast);
             }
         }

        // SOUTHERN?
        if (index < ((this.Size * this.Size) - this.Size)) {
            int indexSouth = index + this.Size;

            // SOUTH EAST
            if ((index % this.Size) != (this.Size - 1)) {
                int indexSouthEast = indexSouth + 1;
                if (IsUnvisited(indexSouthEast)) {
                    neighbors.Add(indexSouthEast);
                }
            }

            // SOUTH?
            if (IsUnvisited(indexSouth)) {
                neighbors.Add(indexSouth);
            }

            // SOUTH-WEST?
            if ((index % this.Size) != (0)) {
                int indexSouthWest = indexSouth - 1;
                if (IsUnvisited(indexSouthWest)) {
                    neighbors.Add(indexSouthWest);
                }}
        }

        // WEST?
        if ((index % this.Size) != 0) {
            int indexWest = index - 1;
            if (IsUnvisited(indexWest)) {
                neighbors.Add(indexWest);
            }

            // NORTH-WEST?
            if (index > this.Size) {
                int indexNorthWest = index - (this.Size + 1);
                if (IsUnvisited(indexNorthWest)) {
                    neighbors.Add(indexNorthWest);
                }
            }
        }

        return neighbors.ToArray();
    }
    
    public bool IsUnvisited(int index)
    {
        // Is the node of the specified index still unvisited?
        return (this.Unvisited[index] == true);
    }

    public void Obstructed(int index)
    {
        // Convienence wrapper
        Visited(index);
    }

    public void Visited(int index)
    {
        this.Unvisited[index] = false;
        this.UnvisitedCount--;
    }
}
