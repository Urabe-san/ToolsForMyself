/*
  FTouchGo.go
  Only for Windows.
  This program source use syscall.
*/

package main

import (
	"fmt"
	"os"
	"syscall" // syscall for Windows platform.
	"time"    //https://golang.org/pkg/time/#Location
)

func usage() {
	fmt.Printf("FTouchGo by Urabe-san. Aug. 2024 \n\n")
	fmt.Printf("USAGE: \n")
	fmt.Printf(" FTouchGo [option] [timestamp] [filename]")
	fmt.Printf("  option\n")
	fmt.Printf("   C or c: change create time\n")
	fmt.Printf("   M or m: change modify time\n")
	fmt.Printf("   A or a: change access time\n\n")
	fmt.Printf("")
	fmt.Printf("  timestamp\n")
	fmt.Printf("   yyyy-MM-ddTHH:mm:ss\n\n")
}

func StringToTime(timestamp string) time.Time {
	var ParseTime time.Time
	var layout string = "2006-01-02T15:04:05"

	ParseTime, _ = time.Parse(layout, timestamp)
	return ParseTime
}

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

	FileDateTime = syscall.NsecToFiletime(TimeValue.UnixNano())
	if "C" == option || "c" == option {
		err = syscall.SetFileTime(handle, &FileDateTime, nil, nil)
	} else if "M" == option || "m" == option {
		err = syscall.SetFileTime(handle, nil, nil, &FileDateTime)
	} else if "A" == option || "a" == option {
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

	option = os.Args[1]
	timestamp = os.Args[2]
	filename = os.Args[3]

	TimestampValue = StringToTime(timestamp)

	if false == ChangeTimeStamp(option, TimestampValue, filename) {
		fmt.Printf("ERROR: fail to change timestamp.\n")
	}

}
