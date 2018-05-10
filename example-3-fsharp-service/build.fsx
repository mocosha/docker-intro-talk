#r "./packages/FAKE/tools/FakeLib.dll"

// NOTE: to avoid multiple restores, all build-related operations are using `--no-restore` flag, because package restore is being done by Restore target

open System
open System.IO
open Fake

let artifacts =
    ["./SampleService/SampleService.fsproj"]


// Helpers
let getBuildNo () =
    match buildServer with
    | TeamCity | Jenkins | CCNet -> buildVersion
    | _ -> "0"

let getExecutablePath executableName =
    match tryFindFileOnPath executableName with
    | Some x -> x
    | None -> failwithf "%s is not installed" executableName


Target "Clean" <| fun _ ->
    !! "src/*/*/bin"
     ++ "src/*/*/obj"
     ++ "test/*/bin"
     ++ "test/*/obj"
    |> CleanDirs

Target "Restore" <| fun _ ->
    DotNetCli.Restore <|fun p ->
        { p with
            NoCache = false }

Target "Build" <| fun _ ->
    DotNetCli.Build <| fun p ->
        { p with
            Configuration = "Release"
            AdditionalArgs = ["--no-restore"] }


Target "Publish" <| fun _ ->
    let buildNo = getBuildNo ()
    let artifactsDir = sprintf "./artifacts/%s" buildNo

    CreateDir artifactsDir
    CleanDir artifactsDir

    let makeArtifact proj =
        let projectDir = FileHelper.directory proj
        let publishFolderPath = combinePaths projectDir "/deploy/"
        let projectName = FileHelper.fileNameWithoutExt proj

        CreateDir publishFolderPath
        CleanDir publishFolderPath

        DotNetCli.Publish <| fun p ->
            { p with
                Project = proj
                Configuration = "Release"
                Output = "deploy"
                AdditionalArgs = ["--no-restore"] }

        !! (publishFolderPath + "**/*.*")
         -- "*.zip"
        |> Zip publishFolderPath (sprintf "%s/%s-%s.zip" artifactsDir projectName buildNo)

        DeleteDir publishFolderPath

    Seq.iter makeArtifact artifacts

// Build order
"Clean"
  ==> "Restore"
  ==> "Build"
  ==> "Publish"

// e2e

// Default target
let defaultTarget =
    if isLocalBuild then "Build"
    else "Publish"

RunTargetOrDefault defaultTarget
