# Dockerfile for image: theronh/mapgenerator
# 
# Sample docker build command:
# docker build -f "Dockerfile" -t theronh/mapgenerator "."

FROM matlabruntime/r2023b/release/update7/108000000000000000

COPY ./applicationFilesForMATLABCompiler /usr/bin/mlrtapp
RUN chmod -R a+rX /usr/bin/mlrtapp/*

RUN if ["$(getent passwd appuser | cut -d: -f1)" = ""] ; then useradd -ms /bin/bash appuser ; fi
USER appuser

ENTRYPOINT ["/opt/matlabruntime/R2023b/bin/glnxa64/muserve", "-a", "/usr/bin/mlrtapp/mapGenerator.ctf"]
