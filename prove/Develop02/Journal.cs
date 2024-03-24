using System;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries in the journal.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetEntryAsCSV());
            }
        }

        Console.WriteLine("Journal saved to " + filename + " successfully!");
    }

    public void LoadFromFile(string filename)
    {
        List<Entry> loadedEntries = new List<Entry>();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            Entry entry = new Entry(parts[0], parts[1], parts[2]);
            loadedEntries.Add(entry);
        }

        _entries = loadedEntries;
        Console.WriteLine("Journal loaded from " + filename + " successfully!");
    }
}