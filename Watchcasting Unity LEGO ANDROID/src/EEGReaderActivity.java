package com.kpicture.unityeegreader;

import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothManager;
import android.content.Context;
import android.content.Intent;

import com.emotiv.insight.IEdk;
import com.emotiv.insight.IEdkErrorCode;
import com.emotiv.insight.IEdk.IEE_DataChannel_t;
import com.emotiv.insight.IEdk.IEE_Event_t;
import com.unity3d.player.UnityPlayerActivity;

public class EEGReaderActivity extends UnityPlayerActivity {

	private static final int REQUEST_ENABLE_BT = 1;
	private BluetoothAdapter mBluetoothAdapter;
	private boolean lock = false;
	private boolean isEnablGetData = false;
	private boolean isEnableWriteFile = false;
	int userId;
	public static String currentData = "nothing here!";
	Button Start_button,Stop_button;
	IEE_DataChannel_t[] Channel_list = {IEE_DataChannel_t.IED_AF3, IEE_DataChannel_t.IED_T7,IEE_DataChannel_t.IED_Pz,
		IEE_DataChannel_t.IED_T8,IEE_DataChannel_t.IED_AF4};
	String[] Name_Channel = {"AF3","T7","Pz","T8","AF4"};
	@Override
	protected void onCreate(Bundle savedInstanceState) {
	//	super.onCreate(savedInstanceState);
//		setContentView(R.layout.activity_main);

		final BluetoothManager bluetoothManager =
			(BluetoothManager) getSystemService(Context.BLUETOOTH_SERVICE);
		mBluetoothAdapter = bluetoothManager.getAdapter();
		if (!mBluetoothAdapter.isEnabled()) {
			if (!mBluetoothAdapter.isEnabled()) {
				Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
				startActivityForResult(enableBtIntent, REQUEST_ENABLE_BT);
			}
		}
			

		//Connect to emoEngine
		IEdk.IEE_EngineConnect(this,"");
		Thread processingThread=new Thread()
		{
			@Override
			public void run() {
				// TODO Auto-generated method stub
				super.run();
				while(true)
				{
					try
					{
						handler.sendEmptyMessage(0);
						handler.sendEmptyMessage(1);
						handler.sendEmptyMessage(2);
						Thread.sleep(5);
					}

					catch (Exception ex)
					{
						ex.printStackTrace();
					}
				}
			}
		};		
		processingThread.start();
	}

	Handler handler = new Handler() {
		@Override
		public void handleMessage(Message msg) {
			switch (msg.what) {

			case 0:
				int state = IEdk.IEE_EngineGetNextEvent();
				if (state == IEdkErrorCode.EDK_OK.ToInt()) {
					int eventType = IEdk.IEE_EmoEngineEventGetType();
					userId = IEdk.IEE_EmoEngineEventGetUserId();
					if(eventType == IEE_Event_t.IEE_UserAdded.ToInt()){
						Log.e("SDK","User added");
						IEdk.IEE_FFTSetWindowingType(userId, IEdk.IEE_WindowsType_t.IEE_BLACKMAN);
						isEnablGetData = true;
					}
					if(eventType == IEE_Event_t.IEE_UserRemoved.ToInt()){
						Log.e("SDK","User removed");		
						isEnablGetData = false;
					}
				}

				break;
			case 1:
				/*Connect device with Insight headset*/
				int number = IEdk.IEE_GetInsightDeviceCount();
				if(number != 0) {
					if(!lock){
						lock = true;
						IEdk.IEE_ConnectInsightDevice(0);
					}
				}
				/**************************************/
				/*Connect device with Epoc Plus headset*/
				//				int number = IEdk.IEE_GetEpocPlusDeviceCount();
				//				if(number != 0) {
				//					if(!lock){
				//						lock = true;
				//						IEdk.IEE_ConnectEpocPlusDevice(0,false);
				//					}
				//				}
				/**************************************/
				else lock = false;
				break;
			case 2:
				for(int i=0; i < Channel_list.length; i++)
				{
					double[] data = IEdk.IEE_GetAverageBandPowers(Channel_list[i]);
					if(data.length == 5){
							currentData += Name_Channel[i] + ",";
							for(int j=0; j < data.length;j++)
								currentData += String.valueOf(data[j]) + ",";							
					}
				}

				break;
			}

		}

	};
	public static String getCurrentData() {
		return currentData;
	}
}
