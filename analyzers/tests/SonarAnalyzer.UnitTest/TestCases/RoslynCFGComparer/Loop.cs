using System;
using System.IO;
using System.Reflection;
using System.Threading;

public class Sample
{
    public void WhileTrueBreak()
    {
        while (true)
        {
            var beforeBreak = "BeforeBreak";
            break;
            var afterBreak = "AfterBreak";
        }
    }

    public void WhileTrueReturn()
    {
        while (true)
        {
            var beforeReturn = "BeforeReturn";
            return;
            var afterReturn = "afterReturn";
        }
    }

    public void WhileAndOr(bool a, bool b, bool c)
    {
        while (a && (b || c))
        {
            a = false;
        }
    }

    public void DoWhile()
    {
        string value = null;
        do
        {
            value = "Value";
        } while (value == null);
    }

    public void DoContinue()
    {
        var i = 0;
        do
        {
            i++;
            if (i < 5)
            {
                continue;
            }
            i += 10;
        } while (i < 10);
    }

    public void For()
    {
        for (var i = 0; i < 10; i++)
        {
            var value = "Value";
        }
    }

    public void ForEach()
    {
        foreach (var i in new[] { 0, 1, 2, 4, 8, 16 })
        {
            var value = i.ToString();
        }
    }

    public void Tainted_For(int tainted)
    {
        for (var i = 0; i < tainted; i++)
        {
            ExpensiveCall();
        }
    }

    public void Tainted_For_Complex(bool conditionA, bool conditionB, int tainted)
    {
        for (var i = 0; conditionA && i < tainted && conditionB; i++)
        {
            ExpensiveCall();
        }
    }

    public void Tainted_While(int tainted)
    {
        var i = 0;
        while (i < tainted)
        {
            ExpensiveCall();
            i++;
        }
    }

    public void Tainted_Do(int tainted)
    {
        var i = 0;
        do
        {
            ExpensiveCall();
            i++;
        }
        while (i < tainted);
    }

    public void Tainted_GoTo(int tainted)
    {
        var i = 0;
    Start:
        if(i < tainted)
        {
            ExpensiveCall();
            i++;
            goto Start;
        }
    }

    private void ExpensiveCall() { }
}
