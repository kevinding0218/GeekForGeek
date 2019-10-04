using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    /// <summary>
    /// Leetcode 609
    /// Given a list of directory info including directory path, and all the files with contents in this directory, 
    /// you need to find out all the groups of duplicate files in the file system in terms of their paths.
    /// A group of duplicate files consists of at least two files that have exactly the same content.
    /// A single directory info string in the input list has the following format:
    /// "root/d1/d2/.../dm f1.txt(f1_content) f2.txt(f2_content) ... fn.txt(fn_content)"
    /// It means there are n files(f1.txt, f2.txt ... fn.txt with content f1_content, f2_content ... fn_content, respectively) in directory root/d1/d2/.../dm.Note that n >= 1 and m >= 0. If m = 0, it means the directory is just the root directory.
    /// The output is a list of group of duplicate file paths. For each group, it contains all the file paths of the files that have the same content. A file path is a string that has the following format:
    /// "directory_path/file_name.txt"
    /// Example 1:
    /// Input:
    /// ["root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)"]
    /// Output:  
    /// [["root/a/2.txt","root/c/d/4.txt","root/4.txt"], ["root/a/1.txt","root/c/3.txt"]]
    /// </summary>
    public static class FindDuplicateFile
    {
        /// <summary>
        /// For the brute force solution, firstly we obtain the directory paths, the filenames and file contents separately 
        /// by appropriately splitting the elements of the pathspaths list. While doing so, we keep on creating a listlist 
        /// which contains the full path of every file along with the contents of the file. 
        /// 
        /// The listlist contains data in the form 
        /// [ [file_1_full_path, file_1_contents], [file_2_full_path, file_2_contents]..., [file_n_full_path, file_n_contents] ]
        /// Once this is done, we iterate over this list.
        /// For every element i chosen from the list, we iterate over the whole list to find another element j 
        /// whose file contents are the same as the i th element.
        /// For every such element found, we put the j th element's file path in a temporary list l and we also mark the j th
        /// element as visited so that this element isn't considered again in the future. 
        /// Thus, when we reach the end of the array for every i th element, we obtain a list of file paths in l, 
        /// which have the same contents as the file corresponding to the ith element.
        /// If this list isn't empty, it indicates that there exists content duplicate to the i th element. 
        /// Thus, we also need to put the i th element's file path in the l.
        /// At the end of each iteration, we put this list ll obtained in the resultant list resres and reset the list l 
        /// for finding the duplicates of the next element.
        /// </summary>
        /// Time complexity : O(n*x + f^2*s) Space complexity : O(n*x)
        /// <returns></returns>
        public static List<List<string>> BruteForce(string[] paths)
        {
            List<String[]> list = new List<String[]>();
            foreach (String path in paths)
            {
                // e.g path: "root/a 1.txt(abcd) 2.txt(efgh)"
                String[] values = path.Split(" ");
                for (int i = 1; i < values.Length; i++)
                {
                    String[] name_cont = values[i].Split("\\(");
                    name_cont[1] = name_cont[1].Replace(")", "");
                    list.Add(new String[] {
                    values[0] + "/" + name_cont[0], name_cont[1]
                });
                }
            }
            bool[] visited = new bool[list.Count];
            List<List<String>> res = new List<List<String>>();
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (visited[i])
                    continue;
                List<String> l = new List<String>();
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i][1] == (list[j][1]))
                    {
                        l.Add(list[j][0]);
                        visited[j] = true;
                    }
                }
                if (l.Count > 0)
                {
                    l.Add(list[i][0]);
                    res.Add(l);
                }
            }
            return res;
        }

        /// <summary>
        /// In this approach, firstly we obtain the directory paths, 
        /// the file names and their contents separately by appropriately splitting each string in the given pathspaths list. 
        /// In order to find the files with duplicate contents, we make use of a HashMap map, 
        /// which stores the data in the form (contents,list of <file => paths/filename>). 
        /// Thus, for every file's contents, we check if the same content already exist in the hashmap. 
        /// If so, we add the current file's path to the list of files corresponding to the current contents. 
        /// Otherwise, we create a new entry in the mapmap, with the current contents as the key and the value being a list 
        /// with only one entry(the current file's path).
        /// At the end, we find out the contents corresponding to which atleast two file paths exist.
        /// We obtain the resultant list resres, which is a list of lists containing these file paths corresponding to the same contents.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static List<List<string>> HashMap(string[] paths)
        {
            Dictionary<String, List<String>> dic = new Dictionary<String, List<String>>();
            foreach (String path in paths)
            {
                // e.g path: "root/a 1.txt(abcd) 2.txt(efgh)"
                String[] values = path.Split(" ");
                // for each filename and content
                for (int i = 1; i < values.Length; i++)
                {
                    String[] name_cont = values[i].Split("\\(");
                    // e.g name_cont[1] = abcd / efgh
                    name_cont[1] = name_cont[1].Replace(")", "");
                    List<String> list;
                    dic.TryGetValue(name_cont[1], out list);
                    // list.Add(root/a/1.txt)
                    list.Add(values[0] + "/" + name_cont[0]);
                    dic.Add(name_cont[1], list);
                }
            }

            List<List<String>> res = new List<List<String>>();
            foreach (String key in dic.Keys)
            {
                List<String> list;
                dic.TryGetValue(key, out list);
                if (list.Count > 1)
                    res.Add(list);
            }
            return res;
        }
    }
}
