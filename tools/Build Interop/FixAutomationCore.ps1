param (
    [Parameter(Mandatory=$true)]
    [string]$file
)

$content = [System.IO.File]::ReadAllText($file)

$content = $content.Replace(
@"
  .method public hidebysig newslot abstract virtual 
          instance void  RegisterPattern([in] valuetype Interop.UIAutomationCore.UIAutomationPatternInfo& pattern,
                                         [out] int32& pPatternId,
                                         [out] int32& pPatternAvailablePropertyId,
                                         [in] uint32 propertyIdCount,
                                         [out] int32& pPropertyIds,
                                         [in] uint32 eventIdCount,
                                         [out] int32& pEventIds) runtime managed internalcall
"@,
@"
  .method public hidebysig newslot abstract virtual 
          instance void  RegisterPattern([in] valuetype Interop.UIAutomationCore.UIAutomationPatternInfo& pattern,
                                         [out] int32& pPatternId,
                                         [out] int32& pPatternAvailablePropertyId,
                                         [in] uint32 propertyIdCount,
                                         [out] int32[] marshal([+3]) pPropertyIds,
                                         [in] uint32 eventIdCount,
                                         [out] int32[] marshal([+5]) pEventIds) runtime managed internalcall
"@)

$content = $content.Replace(
@"
  .method public hidebysig newslot virtual 
          instance void  RegisterPattern([in] valuetype Interop.UIAutomationCore.UIAutomationPatternInfo& pattern,
                                         [out] int32& pPatternId,
                                         [out] int32& pPatternAvailablePropertyId,
                                         [in] uint32 propertyIdCount,
                                         [out] int32& pPropertyIds,
                                         [in] uint32 eventIdCount,
                                         [out] int32& pEventIds) runtime managed internalcall
"@,
@"
  .method public hidebysig newslot virtual 
          instance void  RegisterPattern([in] valuetype Interop.UIAutomationCore.UIAutomationPatternInfo& pattern,
                                         [out] int32& pPatternId,
                                         [out] int32& pPatternAvailablePropertyId,
                                         [in] uint32 propertyIdCount,
                                         [out] int32[] marshal([+3]) pPropertyIds,
                                         [in] uint32 eventIdCount,
                                         [out] int32[] marshal([+5]) pEventIds) runtime managed internalcall
"@)

$content = $content.Replace(
@"
  .method public hidebysig newslot abstract virtual 
          instance void  CallMethod([in] uint32 index,
                                    [in] valuetype Interop.UIAutomationCore.UIAutomationParameter& pParams,
                                    [in] uint32 cParams) runtime managed internalcall
"@,
@"
  .method public hidebysig newslot abstract virtual 
          instance int32 CallMethod([in] uint32 index,
                                    [in] valuetype Interop.UIAutomationCore.UIAutomationParameter[] marshal([+2]) pParams,
                                    [in] uint32 cParams) runtime managed internalcall preservesig
"@)

$content = $content.Replace(
@"
  .method public hidebysig newslot abstract virtual 
          instance void  GetProperty([in] uint32 index,
                                     [in] int32 cached,
                                     [in] valuetype Interop.UIAutomationCore.UIAutomationType 'type',
                                     [out] native int pPtr) runtime managed internalcall
"@,
@"
  .method public hidebysig newslot abstract virtual 
          instance int32 GetProperty([in] uint32 index,
                                     [in] int32 cached,
                                     [in] valuetype Interop.UIAutomationCore.UIAutomationType 'type',
                                     [out] native int pPtr) runtime managed internalcall preservesig
"@)

$content = $content.Replace(
@"
  .method public hidebysig newslot abstract virtual 
          instance void  Dispatch([in] object  marshal( iunknown ) pTarget,
                                  [in] uint32 index,
                                  [in] valuetype Interop.UIAutomationCore.UIAutomationParameter& pParams,
                                  [in] uint32 cParams) runtime managed internalcall
"@,
@"
  .method public hidebysig newslot abstract virtual 
          instance void  Dispatch([in] object  marshal( iunknown ) pTarget,
                                  [in] uint32 index,
                                  [in] valuetype Interop.UIAutomationCore.UIAutomationParameter[] marshal([+3]) pParams,
                                  [in] uint32 cParams) runtime managed internalcall
"@)

$content = $content.Replace(
@"
.class public sequential ansi sealed beforefieldinit Interop.UIAutomationCore.UIAutomationPropertyInfo
       extends [mscorlib]System.ValueType
{
  .pack 4
"@,
@"
.class public sequential ansi sealed beforefieldinit Interop.UIAutomationCore.UIAutomationPropertyInfo
       extends [mscorlib]System.ValueType
{
  .pack 0
"@)

$content = $content.Replace(
@"
.class public sequential ansi sealed beforefieldinit Interop.UIAutomationCore.UIAutomationEventInfo
       extends [mscorlib]System.ValueType
{
  .pack 4
"@,
@"
.class public sequential ansi sealed beforefieldinit Interop.UIAutomationCore.UIAutomationEventInfo
       extends [mscorlib]System.ValueType
{
  .pack 0
"@)

$content = $content.Replace(
@"
.class public sequential ansi sealed beforefieldinit Interop.UIAutomationCore.UIAutomationPatternInfo
       extends [mscorlib]System.ValueType
{
  .pack 4
"@,
@"
.class public sequential ansi sealed beforefieldinit Interop.UIAutomationCore.UIAutomationPatternInfo
       extends [mscorlib]System.ValueType
{
  .pack 0
"@)

$content = $content.Replace(
@"
.class public sequential ansi sealed beforefieldinit Interop.UIAutomationCore.UIAutomationParameter
       extends [mscorlib]System.ValueType
{
  .pack 4
"@,
@"
.class public sequential ansi sealed beforefieldinit Interop.UIAutomationCore.UIAutomationParameter
       extends [mscorlib]System.ValueType
{
  .pack 0
"@)

$content = $content.Replace(
@"
.class public sequential ansi sealed beforefieldinit Interop.UIAutomationCore.UIAutomationMethodInfo
       extends [mscorlib]System.ValueType
{
  .pack 4
"@,
@"
.class public sequential ansi sealed beforefieldinit Interop.UIAutomationCore.UIAutomationMethodInfo
       extends [mscorlib]System.ValueType
{
  .pack 0
"@)

[System.IO.File]::WriteAllText($file, $content)