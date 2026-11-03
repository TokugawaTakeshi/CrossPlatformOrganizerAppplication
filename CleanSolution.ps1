$logFile = "DeletedFolders.log"
$targetNames = @("obj", "bin")

$foldersToDelete = Get-ChildItem -Directory -Recurse -Force |
  Where-Object { 
    $targetNames -contains $_.Name -and $_.FullName -notmatch '[\\/]node_modules[\\/]'
  }

if ($foldersToDelete.Count -eq 0) {
  Write-Host "No matching folders found." -ForegroundColor Yellow
  return
}

Write-Host "The following folders will be deleted:" -ForegroundColor Cyan
$foldersToDelete | ForEach-Object { Write-Host $_.FullName -ForegroundColor White }

$confirm = Read-Host "Do you want to delete ALL of these folders? (Y/N)"

if ($confirm -match '^[Yy]$') {

  foreach ($folder in $foldersToDelete) {
  
    $folderPath = $folder.FullName
    
    try {
      Remove-Item -LiteralPath $folderPath -Recurse -Force
      Add-Content -Path $logFile -Value "Deleted: $folderPath | $(Get-Date)"
      Write-Host "Deleted: $folderPath" -ForegroundColor Green
    }
    catch {
      Add-Content -Path $logFile -Value "Failed to delete: $folderPath | $_ | $(Get-Date)"
      Write-Host "Failed to delete: $folderPath" -ForegroundColor Red
    }
    
  }
  
} else {
  Write-Host "Deletion cancelled." -ForegroundColor Yellow
}