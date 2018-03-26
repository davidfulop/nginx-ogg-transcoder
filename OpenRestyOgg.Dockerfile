FROM openresty/openresty:xenial

RUN apt-get update && apt-get install -y apt-transport-https
RUN apt-get install -y ffmpeg
