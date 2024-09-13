/*
  GetDirectorySize.go
*/
/*
  go build -a -ldflags="-s -w" -trimpath -o DirectorySize.exe
*/

package main

import (
	"fmt"
	"os"
	"path/filepath"
)

type FileInformationStruct struct {
	IsDirectory bool
	FilePath    string
	FileSize    int64
}

func usage() {
	var execfile string

	path, _ := os.Executable()
	execfile = filepath.Base(path)

	fmt.Printf("GetDirectorySize by Urabe-san. Sep. 2024 \n\n")
	fmt.Printf("USAGE: \n")
	fmt.Printf(" " + execfile + " [Path]\n")
}

func GetTargetDirectorySize(TargetPath string) FileInformationStruct {
	var result FileInformationStruct
	var Temporary FileInformationStruct

	result.IsDirectory = true
	result.FilePath = TargetPath
	result.FileSize = 0
	DirectoryElements := make([]FileInformationStruct, 0)

	files, err := os.ReadDir(TargetPath)
	if err != nil {
		fmt.Println("Error reading directory:", err)
		return result
	}

	for _, file := range files {
		if file.IsDir() {
			Temporary = GetTargetDirectorySize(filepath.Join(TargetPath, file.Name()))
		} else {
			Temporary.IsDirectory = false
			Temporary.FilePath = filepath.Join(TargetPath, file.Name())
			Temporary.FileSize = GetFileSize(Temporary.FilePath)
		}
		DirectoryElements = append(DirectoryElements, FileInformationStruct{IsDirectory: Temporary.IsDirectory, FilePath: Temporary.FilePath, FileSize: Temporary.FileSize})
	}

	for _, v := range DirectoryElements {
		result.FileSize += v.FileSize
	}

	return result
}

func GetFileSize(Filepath string) int64 {
	fileInfo, err := os.Stat(Filepath)
	if err != nil {
		fmt.Println("Error getting file info:", err)
		return -1
	}

	return fileInfo.Size()
}

func main() {
	var TargetPath string
	var result FileInformationStruct

	//check command line parameters
	if len(os.Args) < 2 {
		usage()
		return
	}

	TargetPath = os.Args[1] //first params is target path.

	result = GetTargetDirectorySize(TargetPath)
	fmt.Printf("%d\t%s\n", result.FileSize, result.FilePath)
}
