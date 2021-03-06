#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class AkChannelEmitterEx : AkChannelEmitter {
  private global::System.IntPtr swigCPtr;

  internal AkChannelEmitterEx(global::System.IntPtr cPtr, bool cMemoryOwn) : base(AkSoundEnginePINVOKE.CSharp_AkChannelEmitterEx_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkChannelEmitterEx obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  internal override void setCPtr(global::System.IntPtr cPtr) {
    base.setCPtr(AkSoundEnginePINVOKE.CSharp_AkChannelEmitterEx_SWIGUpcast(cPtr));
    swigCPtr = cPtr;
  }

  ~AkChannelEmitterEx() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkChannelEmitterEx(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public AkChannelEmitterEx() : this(AkSoundEnginePINVOKE.CSharp_new_AkChannelEmitterEx(), true) {
  }

  public float occlusion { set { AkSoundEnginePINVOKE.CSharp_AkChannelEmitterEx_occlusion_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkChannelEmitterEx_occlusion_get(swigCPtr); } 
  }

  public float obstruction { set { AkSoundEnginePINVOKE.CSharp_AkChannelEmitterEx_obstruction_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkChannelEmitterEx_obstruction_get(swigCPtr); } 
  }

  public float spread { set { AkSoundEnginePINVOKE.CSharp_AkChannelEmitterEx_spread_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkChannelEmitterEx_spread_get(swigCPtr); } 
  }

  public float focus { set { AkSoundEnginePINVOKE.CSharp_AkChannelEmitterEx_focus_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkChannelEmitterEx_focus_get(swigCPtr); } 
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.