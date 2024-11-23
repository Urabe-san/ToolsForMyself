CLI File Manager Sample Program

Program name: 
	FDop.exe
Parameters: 
	FDop.exe [Option] [File/Directory Name] <Parameter>|<Destination>
Description of parameters:
	[Option]
		These options are not case sensitive.
		create
			Create new empty fils.
			You must specify a file name in [File/Directory Name]. Use either a relative path or an absolute path.
			Only files can be created, directories cannot be created.
			A new empty file cannot be created if a file exists.
			The permissions granted to the folder affect the use of this option.
			If you do not have permission to create a file, it will fail.
		delete
			Deletes a directory or file.
			You must specify the target to be deleted in [File/Directory Name].
			All directories and files contained in the specified directory will be deleted.
			The process will end midway and an error will be displayed, when you do not have permission to delete the subordinate directory or file.
			The permissions granted to the folder affect the use of this option.
			If you do not have permission to delete the file, it will fail.
			If the process is terminated midway, it will not be rolled back and the deleted files will not be restored.
		copy
			Copies files.
			Copying directories is not supported.
			You must specify a file name in [File/Directory Name]. Use either a relative path or an absolute path.
			<Destination> must specify the destination directory.
			Copying a file will fail in the following cases:
				- You do not have access permissions to the source file
				- The source file does not exist
				- You do not have the necessary permissions to the destination directory
				- A file already exists in the destination directory
				- The destination directory does not exist
			If the destination file already exists, there is no confirmation to overwrite it.
			The destination directory will not be created if it does not exist.
			Whether file attributes are inherited depends on the API of the operating system that executed the command.
			Access permissions such as file ownership depend on the API of the operating system that executed the command.
		move
			The behavior is the same as when "copy" is specified. However, the source file will be deleted after the copy is complete.
			If you do not have sufficient permission to operate the file, the process will fail. 
			If the copy is complete but you do not have sufficient permission to delete, the result will be the same as when "copy" is specified.
		rename
			This has the same effect as "move" except when renaming a file within the same directory.
			It will fail if you do not have permission to access the file.
		attribute
			Change file attributes.
			You must specify a directory or file name in [File/Directory Name]. Use either a relative path or an absolute path.
			Specify the content to be changed in <Parameter>.
			The behavior of parameters and options depends on the API of the operating system.
			(If the API treats the error as an exception, a processing error will occur, but if it simply treats it as an error, this command will not return an error.)
		information
			The following information is displayed:
				FILE or DIRECTORY
				File size (only for files)
				Creation date
				Last update date
				Last access date
				Full path of the directory or file
			The information is displayed on a single line, separated by tab characters.
			You must specify a file name in [File/Directory Name]. Use either a relative path or an absolute path.
		list
			A directory path must be specified in [File/Directory Name].
			A file path cannot be specified in [File/Directory Name].
			A list of files under the specified directory will be displayed.
			The display specifications are the same as those for the "information" option.
	[File/Directory Name]
		Specify a directory or file.
		Depending on the options specified in [Option], this may require a full path.
	[Parameter]
		Required if "attribute" is specified in [Option].
			+ or -: add or remove attribute
			Specified attribute (multiple attributes can be specified without separating them with spaces)
				a archive
				r read only
				h hidden
				s system

	<Distination>
		Required if you specify "copy", "move", or "rename" in [Option].


