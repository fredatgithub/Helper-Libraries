namespace DumpManager.Enums
{
    public enum DumpType
    {
        MiniDumpNormal = 0,
        MiniDumpWithDataSegs = 1,
        MiniDumpWithFullMemory = 2,
        MiniDumpWithHandleData = 4,
        MiniDumpFilterMemory = 8,
        MiniDumpScanMemory = 16,
        MiniDumpWithUnloadedModules = 32,
        MiniDumpWithIndirectlyReferencedMemory = 64,
        MiniDumpFilterModulePaths = 128,
        MiniDumpWithProcessThreadData = 256,
        MiniDumpWithPrivateReadWriteMemory = 512,
        MiniDumpWithoutOptionalData = 1024,
        MiniDumpWithFullMemoryInfo = 2048,
        MiniDumpWithThreadInfo = 4096,
        MiniDumpWithCodeSegs = 8192,
    }
}
