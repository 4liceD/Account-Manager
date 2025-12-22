#if UNITY_EDITOR
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class AccountManagerNamespaceMigration
{
    // Old namespaces
    private const string OldNamespaceLoli   = "LoliPoliceDepartment.Utilities.AccountManager";
    private const string OldNamespaceLocal  = "LocalPoliceDepartment.Utilities.AccountManager";

    // New namespace
    private const string NewNamespace       = "_4liceD.Utilities.AccountManager";

    // Menu item in Unity: Account Manager/Migrate Namespaces
    [MenuItem("Account Manager/Migrate Namespaces")]
    public static void MigrateNamespaces()
    {
        // Confirm with the user
        if (!EditorUtility.DisplayDialog(
                "Migrate Account Manager Namespaces",
                "This will scan all C# scripts under Assets/ and replace:\n\n" +
                $" - using {OldNamespaceLoli};\n" +
                $" - using {OldNamespaceLocal};\n" +
                $" - {OldNamespaceLoli}.\n" +
                $" - {OldNamespaceLocal}.\n\n" +
                $"with:\n\n" +
                $" - using {NewNamespace};\n" +
                $" - {NewNamespace}.\n\n" +
                "It's strongly recommended to commit or back up your project first.\n\n" +
                "Continue?",
                "Yes, migrate",
                "Cancel"))
        {
            return;
        }

        string projectPath = Application.dataPath;
        int filesScanned   = 0;
        int filesModified  = 0;

        // Get all .cs files under Assets/
        string[] csFiles = Directory.GetFiles(projectPath, "*.cs", SearchOption.AllDirectories);

        try
        {
            AssetDatabase.StartAssetEditing();

            foreach (string filePath in csFiles)
            {
                filesScanned++;

                string text = File.ReadAllText(filePath, Encoding.UTF8);
                string original = text;

                // Replace using directives
                text = text.Replace($"using {OldNamespaceLoli};",  $"using {NewNamespace};");
                text = text.Replace($"using {OldNamespaceLocal};", $"using {NewNamespace};");

                // Replace fully-qualified type usages
                text = text.Replace($"{OldNamespaceLoli}.",  $"{NewNamespace}.");
                text = text.Replace($"{OldNamespaceLocal}.", $"{NewNamespace}.");

                if (text != original)
                {
                    // Optional: create a .bak backup
                    string backupPath = filePath + ".bak_before_namespace_migration";
                    if (!File.Exists(backupPath))
                    {
                        File.WriteAllText(backupPath, original, Encoding.UTF8);
                    }

                    File.WriteAllText(filePath, text, Encoding.UTF8);
                    filesModified++;
                }
            }
        }
        finally
        {
            AssetDatabase.StopAssetEditing();
            AssetDatabase.Refresh();
        }

        EditorUtility.DisplayDialog(
            "Namespace Migration Complete",
            $"Scanned {filesScanned} C# files.\n" +
            $"Modified {filesModified} files.\n\n" +
            "Any changed files have a '.bak_before_namespace_migration' backup next to them.",
            "OK");
    }
}
#endif
