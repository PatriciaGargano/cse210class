using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public virtual bool Completed { get; protected set; }

    public abstract void MarkComplete();
}

public class SimpleGoal : Goal
{
    public override bool Completed { get; protected set; }

    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override void MarkComplete()
    {
        Completed = true;
    }
}

public class EternalGoal : Goal
{
    public override bool Completed { get; protected set; }

    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override void MarkComplete()
    {
        Value *= 2;
    }
}

public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusValue { get; set; }

    public override bool Completed { get; protected set; }

    public ChecklistGoal(string name, int value, int targetCount, int bonusValue)
    {
        Name = name;
        Value = value;
        TargetCount = targetCount;
        BonusValue = bonusValue;
    }

    public override void MarkComplete()
    {
        CurrentCount++;
        if (CurrentCount == TargetCount)
        {
            Value += BonusValue;
            Completed = true;
        }
    }
}

public class EternalQuest
{
    private List<Goal> goals;
    public int Score { get; private set; }

    public EternalQuest()
    {
        goals = new List<Goal>();
        Score = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.Name == goalName)
            {
                goal.MarkComplete();
                Score += goal.Value;
                break;
            }
        }
    }

    public void ShowGoals()
    {
        foreach (var goal in goals)
        {
            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"{goal.Name} - {(goal.Completed ? "[X]" : "[ ]")} Completed {checklistGoal.CurrentCount}/{checklistGoal.TargetCount} times");
            }
            else
            {
                Console.WriteLine($"{goal.Name} - {(goal.Completed ? "[X]" : "[ ]")}");
            }
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.Name},{goal.Value},{goal.Completed}");
            }
            writer.WriteLine($"Score,{Score}");
        }
    }

    public void LoadGoals(string filename)
    {
        goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts[0] == "Score")
                {
                    Score = int.Parse(parts[1]);
                }
                else
                {
                    Goal goal;
                    if (int.TryParse(parts[1], out int value) && bool.TryParse(parts[2], out bool completed))
                    {
                        if (parts.Length == 3)
                        {
                            goal = new SimpleGoal(parts[0], value);
                        }
                        else if (parts.Length == 5 && int.TryParse(parts[3], out int targetCount) && int.TryParse(parts[4], out int bonusValue))
                        {
                            goal = new ChecklistGoal(parts[0], value, targetCount, bonusValue);
                        }
                        else
                        {
                            goal = new EternalGoal(parts[0], value);
                        }
                        goal.Completed = completed;
                        goals.Add(goal);
                    }
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EternalQuest eternalQuest = new EternalQuest();

        Goal goal1 = new SimpleGoal("Run a Marathon", 1000);
        Goal goal2 = new EternalGoal("Read Scriptures", 100);
        Goal goal3 = new ChecklistGoal("Attend Temple", 50, 10, 500);

        eternalQuest.AddGoal(goal1);
        eternalQuest.AddGoal(goal2);
        eternalQuest.AddGoal(goal3);

        eternalQuest.RecordEvent("Run a Marathon");
        eternalQuest.RecordEvent("Read Scriptures");
        eternalQuest.RecordEvent("Attend Temple");
        eternalQuest.RecordEvent("Attend Temple");
        eternalQuest.RecordEvent("Attend Temple");

        eternalQuest.ShowGoals();
        Console.WriteLine($"Score: {eternalQuest.Score}");

        // You can save and load goals as well
        eternalQuest.SaveGoals("goals.txt");
        eternalQuest.LoadGoals("goals.txt");
    }
}
