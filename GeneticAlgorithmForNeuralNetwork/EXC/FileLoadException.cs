using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithmForNeuralNetwork.EXC
{
    class FileLoadException : Exception
    {
        public FileLoadException(string message)
        : base(message)
    { }
    }
}
