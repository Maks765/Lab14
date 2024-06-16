using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;

public class FileManager : Form
{
    private TreeView directoryTree;
    private ListBox fileList;
    private Button createDirectoryButton, deleteDirectoryButton;
    private Button createFileButton, deleteFileButton, editFileButton;
    private Button editAttributesButton, zipButton, unzipButton;
    private TextBox textEditor;

    public FileManager()
    {
        this.Text = "File Manager";

        // Створення дерева каталогів
        directoryTree = new TreeView();
        directoryTree.Dock = DockStyle.Left;
        directoryTree.AfterSelect += DirectoryTree_AfterSelect;
        Controls.Add(directoryTree);

        // Створення списку файлів
        fileList = new ListBox();
        fileList.Dock = DockStyle.Top;
        Controls.Add(fileList);

        // Створення кнопок
        createDirectoryButton = new Button { Text = "Create Directory" };
        createDirectoryButton.Click += CreateDirectoryButton_Click;
        Controls.Add(createDirectoryButton);

        deleteDirectoryButton = new Button { Text = "Delete Directory" };
        deleteDirectoryButton.Click += DeleteDirectoryButton_Click;
        Controls.Add(deleteDirectoryButton);

        createFileButton = new Button { Text = "Create File" };
        createFileButton.Click += CreateFileButton_Click;
        Controls.Add(createFileButton);

        deleteFileButton = new Button { Text = "Delete File" };
        deleteFileButton.Click += DeleteFileButton_Click;
        Controls.Add(deleteFileButton);

        editFileButton = new Button { Text = "Edit File" };
        editFileButton.Click += EditFileButton_Click;
        Controls.Add(editFileButton);

        editAttributesButton = new Button { Text = "Edit Attributes" };
        editAttributesButton.Click += EditAttributesButton_Click;
        Controls.Add(editAttributesButton);

        zipButton = new Button { Text = "Zip" };
        zipButton.Click += ZipButton_Click;
        Controls.Add(zipButton);

        unzipButton = new Button { Text = "Unzip" };
        unzipButton.Click += UnzipButton_Click;
        Controls.Add(unzipButton);

        // Створення текстового редактора
        textEditor = new TextBox();
        textEditor.Multiline = true;
        textEditor.Dock = DockStyle.Bottom;
        Controls.Add(textEditor);

        PopulateDirectoryTree();
    }

    private void PopulateDirectoryTree()
    {
        directoryTree.Nodes.Clear();
        AddDirectoryToTree(directoryTree.Nodes, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
    }

    private void AddDirectoryToTree(TreeNodeCollection nodes, string path)
    {
        TreeNode node = nodes.Add(Path.GetFileName(path));
        node.Tag = path;

        try
        {
            foreach (string dir in Directory.GetDirectories(path))
            {
                AddDirectoryToTree(node.Nodes, dir);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private void DirectoryTree_AfterSelect(object sender, TreeViewEventArgs e)
    {
        string selectedPath = (string)e.Node.Tag;
        DisplayFilesInDirectory(selectedPath);
    }

    private void DisplayFilesInDirectory(string path)
    {
        fileList.Items.Clear();

        try
        {
            foreach (string file in Directory.GetFiles(path))
            {
                fileList.Items.Add(Path.GetFileName(file));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private void CreateDirectoryButton_Click(object sender, EventArgs e)
    {
        // Implement directory creation logic here
    }

    private void DeleteDirectoryButton_Click(object sender, EventArgs e)
    {
        // Implement directory deletion logic here
    }

    private void CreateFileButton_Click(object sender, EventArgs e)
    {
        // Implement file creation logic here
    }

    private void DeleteFileButton_Click(object sender, EventArgs e)
    {
        // Implement file deletion logic here
    }

    private void EditFileButton_Click(object sender, EventArgs e)
    {
        // Implement file editing logic here
    }

    private void EditAttributesButton_Click(object sender, EventArgs e)
    {
        // Implement file/directory attribute editing logic here
    }

    private void ZipButton_Click(object sender, EventArgs e)
    {
        // Implement file/directory zipping logic here
    }

    private void UnzipButton_Click(object sender, EventArgs e)
    {
        // Implement file/directory unzipping logic here
    }

    static void Main()
    {
        Application.Run(new FileManager());
    }
}
