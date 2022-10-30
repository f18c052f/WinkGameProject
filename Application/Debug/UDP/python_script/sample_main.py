import udp_client
import time
import keyboard

if __name__ == '__main__':

    udp_client = udp_client.Udp_client()

    while True:
        time.sleep(0.01)

        if keyboard.is_pressed("q"):
            udp_client.send_msg_face_detected(True)
        elif keyboard.is_pressed("w"):
            udp_client.send_msg_face_detected(False)

        udp_client.send_msg_right_wink(True)
        # udp_client.send_msg_left_wink(True)