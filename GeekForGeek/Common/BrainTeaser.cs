using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    class BrainTeaser
    {
        /// Q1：Balance Ball Weight
        /// Suppose you had eight/nine identical balls. 
        /// One of them is slightly heavier and you are given a balance scale. 
        /// What's the fewest number of times you have to use the scale to find the heavier ball?
        /// Answer: 2 
        /// Solution: 
        /// (Consider (ABC)(CDF)(GH) OR (ABC)(CDF)(GHI))

        /// Q2：There is a building of 100 floors. If an egg drops from the Nth floor or above it will break.
        /// If it’s dropped from any floor below, it will not break. You’re given 2 eggs.Find N, while
        /// minimizing the number of drops for the worse case.
        /// Answer: 14
        /// Solution: 
        /// Create a system for dropping Egg1 so that the most drops required is consistent,
        /// whether Egg1 breaks on the first drop or the last drop.
        /// 1. A perfectly load balanced system would be one in which Drops of Egg1 + Drops of
        /// Egg2 is always the same, regardless of where Egg1 broke.
        /// 2. For that to be the case, since each drop of Egg1 takes one more step, Egg2 is allowed
        /// one fewer step.
        /// 3. We must, therefore, reduce the number of steps potentially required by Egg2 by one
        /// drop each time. For example, if Egg1 is dropped on Floor 20 and then Floor 30, Egg2 is
        /// potentially required to take 9 steps.When we drop Egg1 again, we must reduce potential
        /// Egg2 steps to only 8. eg, we must drop Egg1 at floor 39.
        /// 4. We know, therefore, Egg1 must start at Floor X, then go up by X-1 floors, then X-2, …,
        /// until it gets to 100.
        /// 5. Solve for X+(X-1)+(X-2)+…+1 = 100. X(X+1)/2 = 100 -> X = 14
        /// We go to Floor 14, then 27, then 39, … This takes 14 steps maximum.
        /// 

        /// Q3: There are 100 closed lockers in a hallway. A man begins by opening all the 100 lockers.
        /// Next, he closes every second locker.Then he goes to every third locker and closes it if it
        /// is open or opens it if it is closed(eg, he toggles every third locker). After his 100th pass in
        /// the hallway, in which he toggles only locker number 100, how many lockers are open?
        /// Answer: There are 10 lockers open
        /// Solution: Door n will be toggled (1 toggle = door opened
        /// or door closed) x times, where x is the number of factors of n.That is, door 20 will be toggled
        /// on round 1, 2, 4, 5, 10, and 20.
        /// Question: When would a door be left open?
        /// Answer: A door is left open if x is odd.You can think about this by pairing factors off as an
        /// open and a close.If there’s one remaining, the door will be open.
        /// Question: When would x be odd?
        /// Answer: x is odd if n is a perfect square.Here’s why: pair n’s factors by their complements.
        /// For example, if n is 36, the factors are (1, 36), (2, 18), (3, 12), (4, 9), (6, 6). Note that(6, 6) only
        /// contributes 1 factor, thus giving n an odd numer of factors.
        /// Question: How many perfect squares are there?
        /// Answer: There are 10 perfect squares. You could count them (1, 4, 9, 16, 36, 49, 64, 81, 100), or
        /// you could simply realize that you can take the numbers 1 through 10 and square them(1*1,
        /// 2*2, 3*3, ..., 10*10).
        /// 


        /// Q4: You have two ropes, and each takes exactly one hour to burn. How would you use them to time exactly 15 minutes?
        /// 1. Light rope 1 at both ends and rope 2 at one end.
        /// 2. When the two flames on Rope 1 meet, 30 minutes will have passed.Rope 2 has 30 minutes left of burn-time.
        /// 3. At that point, light Rope 2 at the other end.
        /// 4. In exactly fifteen minutes, Rope 2 will be completely burnt.
        /// 

        /// Q5: You have 20 bottles of pills. 19 bottles have 1.0 gram pills, 
        /// but one has pills of weight 1.1 grams.Given a scale that provides an exact measurement, how would you find
        /// the heavy bottle? You can only use the scale once.
        /// If we took one pill from Bottle #1 and two pills from Bottle #2, what would the scale
        /// show? It depends.If Bottle #1 were the heavy bottle, we would get 3.1 grams. If Bottle
        /// #2 were the heavy bottle, we would get 3.2 grams. And that is the trick to this problem.
        /// We can generalize this to the full solution: take one pill from Bottle #1, two pills from
        /// Bottle #2, three pills from Bottle #3, and so on. Weigh this mix of pills. If all pills were one
        /// gram each, the scale would read 210 grams(1 + 2 + . . . + 2 0 = 2 0 * 2 1 / 2 =210). 
        /// Any "overage" must come from the extra 0.1 gram pills. 
        /// This formula will tell you the bottle number: (weight - 210 grams) / 0.1 grams.
        /// So, if the set of pills weighed 211.3 grams, then Bottle #13 would have the heavy pills.
        /// 

        /// Q5: A frog is at the bottom of a 30 meter well. 
        /// Each day he summons enough energy for one 3 meter leap up the well. 
        /// Exhausted, he then hangs there for the rest of the day. 
        /// At night, while he is asleep, he slips 2 meters backwards. 
        /// How many days does it take him to escape from the well?
        /// Answer: 28 days
        /// Solution:
        /// Day 1 – It jumps 3 meters. 0 + 3 = 3.
        /// Then falls back 2 at night. 3 – 2 = 1
        /// Day 2 – It jumps 3 meters. 1 + 3 = 4.
        /// Then falls back 2 at night. 4 – 2 = 2.
        /// …
        /// Day 27 – It jumps 3 meters. 26 + 3 = 29.
        /// Then falls back 2 at night. 29 – 2 = 27.
        /// Day 28 – It jumps 3 meters. 27 + 3 = 30
        /// 

        /// Q6: A Russian gangster kidnaps you. 
        /// He puts two bullets in consecutive order in an empty six-round revolver, spins it, points it at your head and shoots. 
        /// You’re still alive. He then asks you, “
        /// do you want me to spin it again and fire or pull the trigger again right away?” 
        /// For each option, what is the probability that you’ll be shot?
        /// The key hint here is that the bullets were loaded adjacent to each other.
        /// There are 4 ways to arrange the revolver with consecutive bullets so that the first shot is blank.These are the possible scenarios:
        /// (xBBxxx)
        /// (xxBBxx)
        /// (xxxBBx)
        /// (xxxxBB)
        /// The other two scenarios would have meant you got shot on the first attempt. (BBxxxx) or(BxxxxB)
        /// Now look at the second slot in those 4 possible scenarios above.Your odds of getting shot are 1/4 or 25%. (Only #1 would get you shot)
        /// But if you respin… there are 2 bullets remaining and 6 total slots. 2/6 or 33%.
        /// 

        /// Q7: 100 coins are lying flat on a table. 10 of them are heads up and 90 are tails up. 
        /// How can we split the coins into two piles such that there are same number of heads up in each pile?
        /// Make 2 piles with 10 coins and 90 coins each. Now, flip all the coins in one of the piles.
        /// Explanation : 
        /// Let’s consider a case
        /// Pile 1: 88T, 2H
        /// Pile 2: 2T, 8H
        /// Flipping the coins in Pile 2
        /// Pile 1: 88T, 2H
        /// Pile 2: 2H, 8T
        /// Pile 1(heads) = Pile 2(heads)


    }
}
