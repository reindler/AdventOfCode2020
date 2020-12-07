using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace AdventOfCode.Days
{
    class Day7 : DayExample
    {
        public Day7() : base("InputDay7.txt")
        {
        }

        public override void Run()
        {
            Part2();
        }

        Regex pattern = new Regex(@"(\d+) ([\w| ]+) bag[s]{0,1}[, |.]");
        private void Part1()
        {
            string[] input = readInputFile();
            Dictionary<string, Bag> bagDict = new Dictionary<string, Bag>();
            foreach (string line in input) {
                int pos = line.IndexOf(" bags contain");
                string containerName = line.Substring(0, pos);
                Bag bag;
                if (bagDict.ContainsKey(containerName))
                {
                    bag = bagDict[containerName];
                }
                else {
                    bag = new Bag(line.Substring(0, pos));
                    bagDict.Add(containerName, bag);
                }

                foreach (Match match in pattern.Matches(line.Substring(pos + " bags contain ".Length))) {
                    int amount = int.Parse(match.Groups[1].Value);
                    string containedBagName = match.Groups[2].Value;
                    bag.addBag(amount, containedBagName);
                    Bag containedBag;
                    if (bagDict.ContainsKey(containedBagName))
                    {
                        containedBag = bagDict[containedBagName];
                    }
                    else {
                        containedBag = new Bag(containedBagName);
                        bagDict.Add(containedBagName, containedBag);
                    }
                    containedBag.addContainer(containerName);
                    //bagDict[containedBagName] = containedBag;
                }
            }

            HashSet<string> bags = new HashSet<string>();
            HashSet<string> curBags = new HashSet<string>(bagDict["shiny gold"].Container);
            while (curBags.Count > 0) {
                string cur = curBags.First();
                curBags.Remove(cur);
                bags.Add(cur);
                foreach (string bag in bagDict[cur].Container) {
                    if (!bags.Contains(bag)) {
                        curBags.Add(bag);
                    }
                }
            }

            Console.WriteLine(bags.Count);
            Console.ReadKey();
        }

        private void Part2()
        {
            string[] input = readInputFile();
            Dictionary<string, Bag> bagDict = new Dictionary<string, Bag>();
            foreach (string line in input)
            {
                int pos = line.IndexOf(" bags contain");
                string containerName = line.Substring(0, pos);
                Bag bag;
                if (bagDict.ContainsKey(containerName))
                {
                    bag = bagDict[containerName];
                }
                else
                {
                    bag = new Bag(line.Substring(0, pos));
                    bagDict.Add(containerName, bag);
                }

                foreach (Match match in pattern.Matches(line.Substring(pos + " bags contain ".Length)))
                {
                    int amount = int.Parse(match.Groups[1].Value);
                    string containedBagName = match.Groups[2].Value;
                    bag.addBag(amount, containedBagName);
                    Bag containedBag;
                    if (bagDict.ContainsKey(containedBagName))
                    {
                        containedBag = bagDict[containedBagName];
                    }
                    else
                    {
                        containedBag = new Bag(containedBagName);
                        bagDict.Add(containedBagName, containedBag);
                    }
                    containedBag.addContainer(containerName);
                    //bagDict[containedBagName] = containedBag;
                }
            }

            Dictionary<string, int> bags = new Dictionary<string, int>();
            Dictionary<string, int> curBags = new Dictionary<string, int>(bagDict["shiny gold"].ContainedBags);
            long count = 0;

            while (curBags.Count > 0)
            {
                KeyValuePair<string, int> cur = curBags.First();
                curBags.Remove(cur.Key);
                if (!bags.Keys.Contains(cur.Key))
                {
                    bags.Add(cur.Key, cur.Value);
                }
                else {
                    bags[cur.Key] += cur.Value;
                }
                    
                count += cur.Value;
                foreach (KeyValuePair<string, int> bag in bagDict[cur.Key].ContainedBags)
                {
                    if (!curBags.Keys.Contains(bag.Key))
                    {
                        curBags.Add(bag.Key, cur.Value * bag.Value);
                    }
                    else {
                        curBags[bag.Key] += cur.Value * bag.Value;
                    }
                }
            }

            
            foreach (KeyValuePair<string, int> bag in bags) {
                Console.WriteLine(bag.Value + " " + bag.Key);
                
            }
            Console.WriteLine("------------------------");
            Console.WriteLine(count + " bags");
            Console.ReadKey();
        }
    }

    public class Bag
    {
        private readonly string color;
        Dictionary<string, int> containedBags;
        List<string> container;

        public string Color => color;

        public Dictionary<string, int> ContainedBags { get => containedBags;}
        public List<string> Container { get => container;}

        public Bag(string color)
        {
            this.color = color;
            containedBags = new Dictionary<string, int>();
            container = new List<string>();
        }

        public void addContainer(string color)
        {
            container.Add(color);
        }

        public void addBag(int amount, string color)
        {
            containedBags.Add(color, amount);
        }
    }
}
