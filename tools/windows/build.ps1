$ErrorActionPreference = "Stop";
$REPO_ROOT = (git rev-parse --show-toplevel).Trim();
$OUTPUT_DIR  = Join-Path $REPO_ROOT "docs\data";
$OUTPUT_FILE = Join-Path $OUTPUT_DIR "readme-paths.txt";

function GenerateFilesList
{
    Get-ChildItem -Path $REPO_ROOT -Recurse -File -Filter "README.md" | ForEach-Object {
        $readmeFile         = $_.FullName;
        $directory          = $_.Directory.FullName;
        $readmeRelativeFile = $_.FullName.Substring($REPO_ROOT.Length + 1);

        Write-Output $readmeRelativeFile;

        Get-ChildItem -Path $directory -Recurse -File -Filter "*.cs" -ErrorAction SilentlyContinue |
        Where-Object {
            $_.FullName -notmatch '\\(bin|obj)\\'
        } |
        ForEach-Object {
            $relativePath = $_.FullName.Substring($REPO_ROOT.Length + 1);
            Write-Output $relativePath;
        }
    }
}

if (-not (Test-Path $OUTPUT_DIR))
{
    New-Item -ItemType Directory -Path $OUTPUT_DIR | Out-Null;
}

GenerateFilesList | Set-Content -Path $OUTPUT_FILE -Encoding UTF8;

Write-Host "$OUTPUT_FILE generated successfully.";
