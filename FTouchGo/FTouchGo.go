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

// remarks:
//
//	If it convert the input characters to a date without modifying, Golang will treat it as a UTC date.
//	When parsing a date/time, if you use "ParseInLocation()" and set the Location to "UTC", it seems to be parsed as local time.
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

	ParseTime, _ = time.ParseInLocation(layout, timestamp, time.UTC) //Convert UTC to Local Date and Time
	fmt.Println(ParseTime.Local().String())
	result = ParseTime

	return result
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

	//FileDateTime = syscall.NsecToFiletime(TimeValue.UnixNano())
	FileDateTime = syscall.NsecToFiletime(TimeValue.Local().UnixNano())
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
