using System;

namespace MatrixNew
{
    class Matrix {
        protected int columns, rows;
        protected double[,] data;

        // public int[,] Data
        // {
        //     get => this.data;
        //     set => this.data = value;
        // }

        // Default Matrix creator
        public Matrix(int rows, int columns){
            this.columns = columns;
            this.rows = rows;

            this.data = new double[this.rows,this.columns];
        }

        // Empty handler
        public Matrix(){
            this.columns = 2;
            this.rows = 2;

            this.data = new double[this.rows,this.columns];
        }

        public void AddData(double data, int row, int column){
            this.data[row, column] += data;
        }
        public double GetData(int row, int column)
        {
            return this.data[row, column];
        }

        public void ReadData(){
            Console.WriteLine("\n\n**************************************************");
            Console.WriteLine("Reading data from keyboard\n");
            for (int row = 0; row < this.rows; row++)
            {
                for (int column = 0; column < this.columns; column++)
                {
                    Console.WriteLine("Data: [{0}, {1}]: ",row,column);
                    this.data[row,column] = Convert.ToDouble(Console.ReadLine());
                }
            }
            Console.WriteLine("Matrix completed.");
        }

        public void DisplayData(){
            Console.WriteLine("\n\n**************************************************");
            Console.WriteLine("Matrix Data\n");
            for (int row = 0; row < this.rows; row++)
            {
                for (int column = 0; column < this.columns; column++)
                {
                    Console.Write(this.data[row,column]+"\t");       
                }
                Console.Write("\n");
            }
        }

        public int Columns
        {
            get => this.columns;
            set => this.columns = value;
        }
        public int Rows
        {
            get => this.rows;
            set => this.rows = value;
        }
    }

    class Program
    {
        static void Production(){
            int rows, columns, columns2;
            Matrix rimM1, rimM2;
            Console.WriteLine("Please enter row count for First Matrix");
            rows = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Please enter column count for First Matrix");
            columns = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Please enter column count for Second Matrix");
            columns2 = Convert.ToInt32(Console.ReadLine());


            if(rows < 1 || columns < 1){
                Console.WriteLine("Fatal Error: Please enter the values bigger than 1");
                Production();
                return;
            }
            
            rimM1 = new Matrix(rows,columns);
            rimM2 = new Matrix(columns,columns2);

            rimM1.ReadData();
            rimM1.DisplayData();

            rimM2.ReadData();
            rimM2.DisplayData();
            
            try
            {
                Matrix rimMR = Multiply(rimM1, rimM2);

                rimMR.DisplayData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Demo(){
            Matrix rimM = new Matrix(2, 3);
            Matrix rimM2 = new Matrix(3, 2);

            // FIRST MATRIX

            rimM.AddData(0, 0, 0);
            rimM.AddData(3, 0, 1);
            rimM.AddData(6, 0, 2);

            rimM.AddData(-1, 1, 0);
            rimM.AddData(-3, 1, 1);
            rimM.AddData(-2, 1, 2);
            rimM.DisplayData();

            // SECOND MATRIX
            rimM2.AddData(5, 0, 0);
            rimM2.AddData(-4, 0, 1);

            rimM2.AddData(3, 1, 0);
            rimM2.AddData(-3, 1, 1);

            rimM2.AddData(-1, 2, 0);
            rimM2.AddData(0, 2, 1);

            rimM2.DisplayData();
            try
            {
                Matrix rimMR = Multiply(rimM, rimM2);

                rimMR.DisplayData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static Matrix Multiply(Matrix fm, Matrix sm){
            Matrix rimMR;
            if(fm.Columns != sm.Rows){
                throw new Exception("These two matrixes cannot be multiplied!");
            }
            rimMR = new Matrix(fm.Rows,sm.Columns);
            for (int r = 0; r < rimMR.Rows; r++){
                for (int c = 0; c < rimMR.Columns; c++)
                {
                    for (int ea = 0; ea < sm.Rows; ea++)
                    {
                        rimMR.AddData( fm.GetData(r,ea) * sm.GetData(ea,c) , r,c);
                    }
                }   
            }
            return rimMR;
        }
        static void Main(string[] args)
        {
            // Production Mode
            Production();
            // Demo Mode
            // Demo();
            
            Console.WriteLine("Hello World!");
        }
    }
}
