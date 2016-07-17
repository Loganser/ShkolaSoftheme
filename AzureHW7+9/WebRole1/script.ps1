Start-Transcript -Path transcript.txt 
New-Item –path .. –name sometext.txt -type "file" ` 
   -value "I was written by a Startup Task!"
Stop-Transcript