using System;
using Google.OrTools.Sat;

public class SolveWithTimeLimitSampleSat
{
  static void Main()
  {
    CpModel model = new CpModel();
    int num_vals = 3;

    IntVar x = model.NewIntVar(0, num_vals - 1, "x");
    IntVar y = model.NewIntVar(0, num_vals - 1, "y");
    IntVar z = model.NewIntVar(0, num_vals - 1, "z");

    model.Add(x != y);

    CpSolver solver = new CpSolver();

    solver.StringParameters = "max_time_in_seconds:10.0";

    CpSolverStatus status = solver.Solve(model);

    if (status == CpSolverStatus.Feasible)
    {
      Console.WriteLine("x = " + solver.Value(x));
      Console.WriteLine("y = " + solver.Value(y));
      Console.WriteLine("z = " + solver.Value(z));
    }
  }
}