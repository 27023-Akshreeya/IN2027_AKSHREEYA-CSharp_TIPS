namespace MemoryOptimization
{
    /// <summary>
    /// Simulates memory consumption by allocating arrays sequentially.
    /// </summary>
    internal class MemoryEater
    {
        /// <summary>
        /// The maximum number of memory blocks to allocate.
        /// </summary>
        public const int AllocationSize = 1000;

        /// <summary>
        /// Holds the collection of allocated integer arrays.
        /// </summary>
        private List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// Continually allocates integer arrays with a short delay until the target size is reached.
        /// </summary>
        public void Allocate()
        {
            while (this._memAlloc.Count < AllocationSize)
            {
                this._memAlloc.Add(new int[1000]);
                Thread.Sleep(10);
            }
        }
    }
}
