/*
  FTouchGo.go
  Only for Windows.
  This program source use syscall.
*/
/*
  go build -a -ldflags="-s -w" -trimpath -o touch.exe
*/

package main

import (
	"fmt"
	"os"
	"path/filepath"
	"syscall" // syscall for Windows platform.
	"time"    //https://golang.org/pkg/time/#Location
)

func usage() {
	var execfile string

	//To accommodate cases where the project name and executable file do not match,
	//the executable file name is obtained dynamically.
	path, _ := os.Executable()
	execfile = filepath.Base(path)

	fmt.Printf("FTouchGo by Urabe-san. Aug. 2024 \n\n")
	fmt.Printf("USAGE: \n")
	fmt.Printf(" " + execfile + " [option] [timestamp] [filename]")
	fmt.Printf("  option\n")
	fmt.Printf("   C or c: change create time\n")
	fmt.Printf("   M or m: change modify time\n")
	fmt.Printf("   A or a: change access time\n\n")
	fmt.Printf("")
	fmt.Printf("  timestamp\n")
	fmt.Printf("   yyyy-MM-ddTHH:mm:ss\n\n")
}

// remarks:
//
//	If it convert the input characters to a date without modifying, Golang will treat it as a UTC date.
//	When parsing a date/time, if you use "ParseInLocation()" and set the Location to "time.Local", it seems to be parsed as local time.
//	However, I could not find any documentation that explains this behavior.
//	I wrote the following source code and tried and tested it.
//
//	  var location *time.Location
//	  location, _ = time.LoadLocation("local")
//	  fmt.Println(location.String())
//	  time.Local = location
//	  fmt.Println(location.String())
//
//	  ParseTime, _ = time.Parse(layout, timestamp)
//	  ParseTime, _ = time.ParseInLocation(layout, timestamp, location)
//	  ParseTime, _ = time.ParseInLocation(layout, timestamp, time.Local)
//	  ParseTime, _ = time.ParseInLocation(layout, timestamp, time.UTC)
//
//	I don't know the specifications or reasons for this behavior.
func StringToTime(timestamp string) time.Time {
	var result time.Time
	var ParseTime time.Time
	var layout string = "2006-01-02T15:04:05"

	ParseTime, _ = time.ParseInLocation(layout, timestamp, time.Local) //Convert UTC to Local Date and Time
	//fmt.Println(ParseTime.String())
	result = ParseTime

	return result
}

// remarks:
//
//	This method uses syscall and only for Windows.
//	Logic for Linux will be added later.
//	There are no plans to implement logic for MacOS.
func ChangeTimeStamp(option string, TimeValue time.Time, fullpathname string) bool {
	var result bool = false
	var err error
	var handle syscall.Handle = 0
	var FileDateTime syscall.Filetime

	handle, err = syscall.Open(fullpathname, syscall.O_RDWR, 0)

	if nil != err {
		result = false
		return result
	}

	defer syscall.Close(handle)

	// fmt.Printf("TimeValue: %s, TimeValue.UTC: %s.\n", TimeValue.String(), TimeValue.UTC().String())
	// fmt.Printf("TimeValue: %d, TimeValue.UTC: %d.\n", TimeValue.UnixNano(), TimeValue.UTC().UnixNano())

	FileDateTime = syscall.NsecToFiletime(TimeValue.Local().UnixNano()) // same value as "TimeValue.UnixNano()"
	if option == "C" || option == "c" {
		err = syscall.SetFileTime(handle, &FileDateTime, nil, nil)
	} else if option == "M" || option == "m" {
		err = syscall.SetFileTime(handle, nil, nil, &FileDateTime)
	} else if option == "A" || option == "a" {
		err = syscall.SetFileTime(handle, nil, &FileDateTime, nil)
	}

	if nil == err {
		result = true
	}

	return result
}

func main() {
	var option string
	var timestamp string
	var filename string

	var TimestampValue time.Time

	//check command line parameters
	if len(os.Args) < 4 {
		usage()
		return
	}

	option = os.Args[1]    //first params is operation option.
	timestamp = os.Args[2] //second params is set timestamp.
	filename = os.Args[3]  //third params is target filename.

	TimestampValue = StringToTime(timestamp)

	if !ChangeTimeStamp(option, TimestampValue, filename) {
		fmt.Printf("ERROR: fail to change timestamp.\n")
	}
}
